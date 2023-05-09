
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using Data.Model;

namespace Services.Core
{
    public interface IBookingScheduleService
    {
        ResultModel Add(BookingScheduleCreateModel model);
        ResultModel Update(BookingScheduleUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class BookingScheduleService : IBookingScheduleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingScheduleService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(BookingScheduleCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<BookingScheduleCreateModel, Data.Entities.BookingSchedule>(model);
                _dbContext.BookingSchedule.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.BookingSchedule, BookingScheduleModel>(data);
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
                var data = _dbContext.BookingSchedule.Where(s => s.bookingScheduleID == id);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<BookingScheduleModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingSchedule" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.BookingSchedule;
                var view = _mapper.ProjectTo<BookingScheduleModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(BookingScheduleUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingSchedule.Where(s => s.bookingScheduleID == model.bookingScheduleID).FirstOrDefault();
                if (data != null)
                {

                    if (model.userID != null)
                    {
                        data.userID = (Guid)model.userID;
                    }
                    if (model.profileID != null)
                    {
                        data.profileID = model.profileID;
                    }
                    if (model.scheduleID != null)
                    {
                        data.scheduleID = model.scheduleID;
                    }
                    if (model.dateBooking != null)
                    {
                        data.dateBooking = model.dateBooking;
                    }
                    if (model.timeBooking != null)
                    {
                        data.timeBooking = model.timeBooking;
                    }
                    if (model.status != null)
                    {
                        data.status = model.status;
                    }


                    //if (model.price != null)
                    //{
                    //    data.price = model.price;
                    //}

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.BookingSchedule, BookingScheduleModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Slot" + ErrorMessage.ID_NOT_EXISTED;
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
