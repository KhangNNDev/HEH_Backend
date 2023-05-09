using AutoMapper;
using Data.DataAccess;
using Data.DataAccess.Constant;
using Data.Model;
using System.Linq;

namespace Services.Core
{
    public interface ISlotService
    {
        ResultModel Add(SlotCreateModel model);
        ResultModel Update(SlotUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByDateAndPhysioID(DateTime date, Guid physioID);
        ResultModel GetByDateAndTypeOfSlot(DateTime date,string typeOfSlot);

    }
    public class SlotService : ISlotService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public SlotService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(SlotCreateModel model)
        {
            var result = new ResultModel();
            var timeStart = _dbContext.Slot.Where(s => s.timeStart == model.timeStart).FirstOrDefault();
            var timeEnd = _dbContext.Slot.Where(s => s.timeEnd == model.timeEnd).FirstOrDefault();
            try
            {
                if (timeStart != null || timeEnd != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Thời Gian Không Hợp Lệ!";
                }
                else
                {
                    var data = _mapper.Map<SlotCreateModel, Data.Entities.Slot>(model);
                    _dbContext.Slot.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
                    result.Succeed = true;

                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Delete(Guid id)
        {
            ResultModel result = new ResultModel();
            try
            {

                var data = _dbContext.Slot.Where(s => s.slotID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
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

        public ResultModel Get(Guid? id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Slot.Where(s => s.slotID == id && !s.isDeleted );
                if (data != null)
                {
                    var view = _mapper.ProjectTo<SlotModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
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

        public ResultModel GetAll()
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Slot.Where(s => s.isDeleted != true );
                var view = _mapper.ProjectTo<SlotModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByDateAndTypeOfSlot(DateTime date, string typeOfSlot)
        {
            ResultModel result = new ResultModel();
            try
            {
                var schedule = _dbContext.Schedule.Where(s => s.Slot.timeStart.Date == date.Date 
                && s.Slot.timeStart.Month == date.Month 
                && s.Slot.timeStart.Year == date.Year 
                && s.typeOfSlotID != null
                && s.TypeOfSlot.typeName == typeOfSlot).ToList();
                List<Guid?> listSlotID = new List<Guid?>();
                if (schedule.Count > 0)
                {

                    foreach (var item in schedule)
                    {
                        int count = 0;
                        foreach (var item1 in schedule)
                        {
                            if (item == item1 && item1.physioBookingStatus == false)
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            listSlotID.Add(item.slotID);
                        }
                        
                    }
                }
                var data = _dbContext.Slot.Where(s => s.timeStart.Date == date.Date && 
                s.timeStart.Month == date.Month && 
                s.timeStart.Year == date.Year && 
                !s.isDeleted && 
                listSlotID.Contains(s.slotID) 
                );
                var view = _mapper.ProjectTo<SlotModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByDateAndPhysioID(DateTime date, Guid physioID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var scheduleRegistered = _dbContext.Schedule.Where(s => s.physiotherapistID == physioID).ToList();
                List<Guid?> listSlotID = new List<Guid?>();
                if (scheduleRegistered.Count > 0)
                {
                    
                    foreach (var schedule in scheduleRegistered)
                    {
                        listSlotID.Add(schedule.slotID);
                    }
                }
                var data = _dbContext.Slot.Where(s => !listSlotID.Contains(s.slotID) && s.timeStart.Year == date.Year && s.timeStart.Month == date.Month && s.timeStart.Day == date.Day  && !s.isDeleted ).OrderBy(x => x.timeStart.Hour);

                if (data != null)
                {
                    var view = _mapper.ProjectTo<SlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
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

        public ResultModel Update(SlotUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Slot.Where(s => s.slotID == model.slotID).FirstOrDefault();
                var timeStart = _dbContext.Slot.Where(s => s.timeStart == model.timeStart).FirstOrDefault();
                var timeEnd = _dbContext.Slot.Where(s => s.timeEnd == model.timeEnd).FirstOrDefault();
                if (data != null)
                {

                    data.slotName = model.slotName;

                
                    data.timeStart = model.timeStart;
                    data.timeEnd = model.timeEnd;
                    data.available = model.available;
                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Slot, SlotModel>(data);


                    

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
