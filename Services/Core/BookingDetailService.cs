using AutoMapper;
using Data.DataAccess;
using Data.DataAccess.Constant;
using Data.Entities;
using Data.Model;

namespace Services.Core
{
    public interface IBookingDetailService
    {
        ResultModel Add(BookingDetailCreateModel model);
        ResultModel Update(BookingDetailUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetByUserIDAndTypeOfSlot(Guid? userID, string typeOfSlot);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetAllBookingDetailByPhysioIDAndTypeOfSlotAndShortTermLongTermStatus(Guid physioID, string typeOfSlot, int shortTermStatus, int longTermStatus);
        ResultModel GetLongTermListByStatus(int shortTermStatus);
    }
    public class BookingDetailService : IBookingDetailService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingDetailService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(BookingDetailCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<BookingDetailCreateModel, Data.Entities.BookingDetail>(model);

                var bookingSchedule = _dbContext.BookingSchedule.Where(s => s.bookingScheduleID == model.bookingScheduleID);
                var bookingScheduleData = _mapper.ProjectTo<BookingScheduleModel>(bookingSchedule).FirstOrDefault();
                var checkSlotOfPhysio = _dbContext.Schedule.Where(s => s.physiotherapistID == bookingScheduleData!.Schedule!.physiotherapistID && s.physioBookingStatus == false).ToList();
                if (checkSlotOfPhysio.Count() <= 1)
                {
                    var physio = _dbContext.Physiotherapist.Where(s => s.physiotherapistID == bookingScheduleData!.Schedule!.physiotherapistID).FirstOrDefault();
                    physio!.scheduleStatus = 0;
                }
                _dbContext.BookingDetail.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.BookingDetail, BookingDetailModel>(data);
                result.Succeed = true;

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResultModel Get(Guid? id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(s => s.bookingDetailID == id);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<BookingDetailModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetAll()
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail;
                var view = _mapper.ProjectTo<BookingDetailModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetAllBookingDetailByPhysioIDAndTypeOfSlotAndShortTermLongTermStatus(Guid physioID, string typeOfSlot, int shortTermStatus, int longTermStatus)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(
                    s => s.BookingSchedule.Schedule.physiotherapistID == physioID &&
                s.BookingSchedule.Schedule.TypeOfSlot.typeName == typeOfSlot 
                && s.shorttermStatus >= shortTermStatus 
                && s.longtermStatus >= longTermStatus
                );
                if (data != null)
                {
                    var view = _mapper.ProjectTo<BookingDetailModel>(data);

                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }



        public ResultModel GetByUserIDAndTypeOfSlot(Guid? userID, string typeOfSlot)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(
                    s => s.BookingSchedule.userID == userID
                    && s.BookingSchedule.Schedule.TypeOfSlot.typeName == typeOfSlot
                    && ((s.shorttermStatus >= 1 && s.shorttermStatus < 3) || (s.longtermStatus >= 1 && s.longtermStatus < 3))
                    );
                if (data != null)
                {
                    var view = _mapper.ProjectTo<BookingDetailModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetLongTermListByStatus(int shortTermStatus)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(s => s.shorttermStatus == shortTermStatus && s.longtermStatus != -1);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<BookingDetailModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(BookingDetailUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(s => s.bookingDetailID == model.bookingDetailID).FirstOrDefault();
                if (data != null)
                {

                    if (model.bookingScheduleID != null)
                    {
                        data.bookingScheduleID = model.bookingScheduleID;
                    }
                    if (model.videoCallRoom != null)
                    {
                        data.videoCallRoom = model.videoCallRoom;
                    }
                    if (data.shorttermStatus != null)
                    {
                        data.shorttermStatus = model.shorttermStatus;
                    }
                    if (data.longtermStatus != null)
                    {
                        data.longtermStatus = model.longtermStatus;
                    }
                    if (data.imageUrl != null)
                    {
                        data.imageUrl = model.imageUrl;
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = data;
                }
                else
                {
                    result.ErrorMessage = "Update BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
    }



}
