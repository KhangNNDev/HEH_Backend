
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using Data.Model;
using Org.BouncyCastle.Asn1.X9;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Data.Utils;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.AspNetCore.Http;

namespace Services.Core
{
    public interface IPaymentService
    {
        ResultModel callVNPayGW(PaymentModel paymentModel, string ipAddress);
        ResultModel callbackVNPayGW(VNPayModel vnpayModel);
        ResultModel checkVNPayGWResult(VNPayModel vnpayModel);
        Guid TestDI();
    }
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IBookingScheduleService _bookingScheduleService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly ITypeOfSlotService _typeOfSlotService;
        private readonly Guid id;

        public Guid TestDI()
        {
            return id;
        }
        public PaymentService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration, UserManager<User> userManager, IUserService userService, IBookingScheduleService bookingScheduleService, ITypeOfSlotService typeOfSlotService, IBookingDetailService bookingDetailService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            id = Guid.NewGuid();
            _userService = userService;
            _bookingScheduleService = bookingScheduleService;
            _typeOfSlotService = typeOfSlotService;
            _bookingDetailService = bookingDetailService;
        }
        public ResultModel callVNPayGW(PaymentModel paymentModel, string ipAddress)
        {
            var result = new ResultModel();

            //Get Config Info
            string vnp_Returnurl = _configuration["vnPay:vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = _configuration["vnPay:vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _configuration["vnPay:vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = _configuration["vnPay:vnp_HashSecret"]; //Chuoi bi mat
            if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
            {
                result.ErrorMessage = "Vui lòng cấu hình các tham số: vnp_TmnCode,vnp_HashSecret trong file web.config";
                result.Succeed = false;
                return result;
            }

            if (paymentModel.email == null)
            {
                result.ErrorMessage = "Vui lòng cung cấp email khách hàng";
                result.Succeed = false;
                return result;
            }

            var user = _userService.GetByEmail(paymentModel.email);
            if (!user.Succeed)
            {
                result.ErrorMessage = user.ErrorMessage;
                result.Succeed = false;
                return result;
            }

            UserModel userData = (UserModel) user.Data;

            //Get payment input
            //Save order to db
            //var OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            var OrderId = paymentModel.orderId;
            var Amount = paymentModel.amount; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
            var Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending"
            var OrderDesc = $"{userData.firstName} thanh toan don hang {paymentModel.orderId}";
            var CreatedDate = DateTime.Now;
            string locale = "vn";
            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            //if (cboBankCode.SelectedItem != null && !string.IsNullOrEmpty(cboBankCode.SelectedItem.Value))
            //{
            //    vnpay.AddRequestData("vnp_BankCode", cboBankCode.SelectedItem.Value);
            //}
            vnpay.AddRequestData("vnp_CreateDate", CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", ipAddress);
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }
            vnpay.AddRequestData("vnp_OrderInfo", OrderDesc);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            //Add Params of 2.1.0 Version
            vnpay.AddRequestData("vnp_ExpireDate", CreatedDate.AddHours(1).ToString("yyyyMMddHHmmss"));
            //Billing
            vnpay.AddRequestData("vnp_Bill_Mobile", userData.phoneNumber); // So DT customer
            vnpay.AddRequestData("vnp_Bill_Email", userData.email);   // Email customer
            var fullName = $"{userData.firstName} {userData.lastName}";
            if (!String.IsNullOrEmpty(fullName))
            {
                var indexof = fullName.IndexOf(' ');
                vnpay.AddRequestData("vnp_Bill_FirstName", fullName.Substring(0, indexof));
                vnpay.AddRequestData("vnp_Bill_LastName", fullName.Substring(indexof + 1, fullName.Length - indexof - 1));
            }
            vnpay.AddRequestData("vnp_Bill_Address", userData.address);
            vnpay.AddRequestData("vnp_Bill_City", "city");
            vnpay.AddRequestData("vnp_Bill_Country", "Viet Nam");
            vnpay.AddRequestData("vnp_Bill_State", "100000");
            // Invoice
            vnpay.AddRequestData("vnp_Inv_Phone", userData.phoneNumber);
            vnpay.AddRequestData("vnp_Inv_Email", userData.email);
            vnpay.AddRequestData("vnp_Inv_Customer", fullName);
            vnpay.AddRequestData("vnp_Inv_Address", userData.address);
            vnpay.AddRequestData("vnp_Inv_Company", "");
            vnpay.AddRequestData("vnp_Inv_Taxcode", "");
            vnpay.AddRequestData("vnp_Inv_Type", "");

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            //log.InfoFormat("VNPAY URL: {0}", paymentUrl);
            result.Data = paymentUrl;
            result.Succeed = true;
            //Response.Redirect(paymentUrl);
            return result;
        }

        public ResultModel callbackVNPayGW(VNPayModel vnpayModel)
        {
            var result = new ResultModel();
            string vnp_HashSecret = _configuration["vnPay:vnp_HashSecret"]; //Secret key
            VnPayLibrary vnpay = createObj(vnpayModel);

            Guid orderId = new Guid(vnpay.GetResponseData("vnp_TxnRef"));
            long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
            //long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            String vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
            if (checkSignature)
            {
                //Cap nhat ket qua GD
                //Yeu cau: Truy van vao CSDL cua  Merchant => lay ra duoc OrderInfo
                //Giả sử OrderInfo lấy ra được như giả lập bên dưới
                //OrderInfo order = new OrderInfo();//get from DB
                var bookingSchedule = _bookingScheduleService.Get(orderId);
                if (bookingSchedule.Succeed && bookingSchedule.Data != null)
                {
                    BookingScheduleModel booking = (BookingScheduleModel) bookingSchedule.Data;
                    if (booking?.Schedule?.TypeOfSlot?.price == vnp_Amount)
                    {
                        var bookingDetail = _bookingDetailService.Get(booking.bookingScheduleID);
                        BookingDetailModel bkDetail = (BookingDetailModel) bookingDetail.Data;
                        var Status = bkDetail != null ? bkDetail.shorttermStatus : 99;
                        if (bkDetail != null && Status == 0)
                        {
                            if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                            {
                                //Thanh toan thanh cong
                                //log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId,
                                //vnpayTranId);
                                result.ErrorMessage = "Thanh toan thanh cong";
                                Status = 1;
                            }
                            else
                            {
                                //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                                //  displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                                //log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}",
                                    //orderId,
                                    //vnpayTranId, vnp_ResponseCode);
                                result.ErrorMessage = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                                Status = 99;
                            }

                            //Thêm code Thực hiện cập nhật vào Database 
                            //Update Database
                            bkDetail.shorttermStatus = Status;
                            var bookingUpdate = _bookingDetailService.Update(bkDetail);
                            if (bookingUpdate.Succeed)
                            {
                                //returnContent = "{\"RspCode\":\"00\",\"Message\":\"Confirm Success\"}";
                                result.ErrorMessage = "Confirm Success";
                                result.Succeed = true;
                            } else
                            {
                                result.ErrorMessage = bookingUpdate.ErrorMessage;
                                result.Succeed = true;
                            }
                        }
                        else
                        {
                            //returnContent = "{\"RspCode\":\"02\",\"Message\":\"Order already confirmed\"}";
                            result.ErrorMessage = "Order already confirmed";
                            result.Succeed = false;
                        }
                    }
                    else
                    {
                        //returnContent = "{\"RspCode\":\"04\",\"Message\":\"invalid amount\"}";
                        result.ErrorMessage = "invalid amount";
                        result.Succeed = false;
                    }
                }
                else
                {
                    //returnContent = "{\"RspCode\":\"01\",\"Message\":\"Order not found\"}";
                    result.ErrorMessage = "Order not found";
                    result.Succeed = false;
                }
            }
            else
            {
                //log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                //returnContent = "{\"RspCode\":\"97\",\"Message\":\"Invalid signature\"}";
                result.ErrorMessage = "Invalid signature";
                result.Succeed = false;
            }
            return result;
        }

        public ResultModel checkVNPayGWResult(VNPayModel vnpayModel)
        {

            var result = new ResultModel();
            string vnp_HashSecret = _configuration["vnPay:vnp_HashSecret"]; //Secret key
            VnPayLibrary vnpay = createObj(vnpayModel);

            //long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            String vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
            if (checkSignature)
            {
                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    //Thanh toan thanh cong
                    result.ErrorMessage = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                    result.Succeed = true;
                }
                else
                {
                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                    result.ErrorMessage = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                    result.Succeed = false;
                }
            }
            else
            {
                result.ErrorMessage = "Có lỗi xảy ra trong quá trình xử lý.";
                result.Succeed = false;
            }
            return result;
        }

        private VnPayLibrary createObj(VNPayModel vnpayModel)
        {
            VnPayLibrary vnpay = new VnPayLibrary();
            //Lay danh sach tham so tra ve tu VNPAY
            //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
            //vnp_TransactionNo: Ma GD tai he thong VNPAY
            //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
            //vnp_SecureHash: HmacSHA512 cua du lieu tra ve
            vnpay.AddResponseData("vnp_TmnCode", vnpayModel.vnp_TmnCode);
            vnpay.AddResponseData("vnp_Amount", vnpayModel.vnp_Amount);
            vnpay.AddResponseData("vnp_BankCode", vnpayModel.vnp_BankCode);
            vnpay.AddResponseData("vnp_BankTranNo", vnpayModel.vnp_BankTranNo);
            vnpay.AddResponseData("vnp_CardType", vnpayModel.vnp_CardType);
            vnpay.AddResponseData("vnp_PayDate", vnpayModel.vnp_PayDate);
            vnpay.AddResponseData("vnp_OrderInfo", vnpayModel.vnp_OrderInfo);
            vnpay.AddResponseData("vnp_TransactionNo", vnpayModel.vnp_TransactionNo);
            vnpay.AddResponseData("vnp_ResponseCode", vnpayModel.vnp_ResponseCode);
            vnpay.AddResponseData("vnp_TransactionStatus", vnpayModel.vnp_TransactionStatus);
            vnpay.AddResponseData("vnp_TxnRef", vnpayModel.vnp_TxnRef);
            vnpay.AddResponseData("vnp_SecureHashType", vnpayModel.vnp_SecureHashType);
            vnpay.AddResponseData("vnp_SecureHash", vnpayModel.vnp_SecureHash);

            return vnpay;
        }
    }
}
