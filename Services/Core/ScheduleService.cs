using AutoMapper;
using Data.DataAccess;
using Data.DataAccess.Constant;
using Data.Entities;
using Data.Model;

namespace Services.Core
{
    public interface IScheduleService
    {
        ResultModel Add(ScheduleCreateModel model);
        ResultModel Update(ScheduleUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

        ResultModel GetAllSlotByPhysiotherapistIDAndTypeOfSlot(Guid physiotherapistID, string typeOfSlot);
        ResultModel GetAllPhysiotherapistBySlotTimeAndSkillAndTypeOfSlot(DateTime timeStart, DateTime timeEnd, string skill, string typeOfSlot);
        ResultModel GetBySlotID(Guid? slotid);
        ResultModel GetNumberOfPhysioRegister(Guid? slotid);
        ResultModel getAllSlotByPhysiotherapistID(Guid physiotherapistID);
        ResultModel GetAllSlotTypeNotAssignedByDateAndPhysioID(DateTime date, Guid physioID);
    }
    public class ScheduleService : IScheduleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;



        public ScheduleService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(ScheduleCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<ScheduleCreateModel, Data.Entities.Schedule>(model);
                
                var physio = _dbContext.Physiotherapist.Where(s => s.physiotherapistID == model.physiotherapistID).FirstOrDefault();
                if (physio!.scheduleStatus == 0)
                {
                    physio.scheduleStatus = 1;
                }
                var slotScheduled = _dbContext.Schedule.Where(s => s.slotID == model.slotID).ToList().Count();
                if (slotScheduled == 4)
                {
                    var slot = _dbContext.Slot.Where(s => s.slotID == model.slotID).FirstOrDefault();
                    if (slot != null )
                    {
                        slot.available = false;
                    }
                }
                _dbContext.Schedule.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.Schedule, ScheduleModel>(data);
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
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.FirstOrDefault();
                if (data != null)
                {

                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Schedule, ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Schedule" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Schedule.Where(s => s.scheduleID == id );
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ScheduleModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Schedule" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Schedule;
                var view = _mapper.ProjectTo<ScheduleModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetAllSlotByPhysiotherapistIDAndTypeOfSlot(Guid physiotherapistID, string typeOfSlot)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.Where(s => s.physiotherapistID == physiotherapistID  &&
                s.typeOfSlotID != null 
                && s.TypeOfSlot.typeName == typeOfSlot);

                if (data != null)
                {


                    var view = _mapper.ProjectTo<ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;



                }
                else
                {
                    result.Succeed = false;
                    result.ErrorMessage = "List of schedule null";
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }

        public ResultModel GetAllPhysiotherapistBySlotTimeAndSkillAndTypeOfSlot(DateTime timeStart, DateTime timeEnd, string skill, string typeOfSlot)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.Where(s =>
                //s.Slot.timeStart == timeStart && s.Slot.timeEnd == timeEnd&&
                s.Slot.timeStart.Date == timeStart.Date &&
                s.Slot.timeStart.Month == timeStart.Month &&
                s.Slot.timeStart.Year == timeStart.Year &&
                s.Slot.timeStart.Hour == timeStart.Hour &&
                s.Slot.timeStart.Minute == timeStart.Minute &&
                s.Slot.timeEnd.Date == timeEnd.Date &&
                s.Slot.timeEnd.Month == timeEnd.Month &&
                s.Slot.timeEnd.Year == timeEnd.Year &&
                s.Slot.timeEnd.Hour == timeEnd.Hour &&
                s.Slot.timeEnd.Minute == timeEnd.Minute &&
                skill.Contains(s.PhysiotherapistDetail.skill)  && 
                s.typeOfSlotID != null && 
                s.TypeOfSlot.typeName == typeOfSlot);

                if (data != null)
                {

                    var view = _mapper.ProjectTo<ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;



                }
                else
                {
                    result.Succeed = false;
                    result.ErrorMessage = "List of schedule null";
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }

        public ResultModel Update(ScheduleUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.Where(s => s.scheduleID == model.scheduleID).FirstOrDefault();
                if (data != null)
                {

                    if (model.slotID != null)
                    {
                        data.slotID = model.slotID;
                    }

                    if (model.physiotherapistID != null)
                    {
                        data.physiotherapistID = model.physiotherapistID;
                    }
                    if (model.typeOfSlotID != null)
                    {
                        data.typeOfSlotID = model.typeOfSlotID;
                    }
                    if (model.description != null)
                    {
                        data.description = model.description;
                    }
                    if (model.physioBookingStatus != null)
                    {
                        data.physioBookingStatus = model.physioBookingStatus;
                    }
                    //if (model.day != null)
                    //{
                    //    data.day = model.day;
                    //}
                    //if (model.price != null)
                    //{
                    //    data.price = model.price;
                    //}

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Schedule, ScheduleModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Schedule" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetBySlotID(Guid? slotid)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.Where(s => s.slotID == slotid);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Schedule" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetNumberOfPhysioRegister(Guid? slotid)
        {
            ResultModel result = new ResultModel();
            try
            {
                var numberRegister = _dbContext.Schedule.Where(s => s.slotID == slotid).ToList().Count();
                result.Data = numberRegister;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel getAllSlotByPhysiotherapistID(Guid physiotherapistID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule.Where(s => s.physiotherapistID == physiotherapistID );

                if (data != null)
                {


                    var view = _mapper.ProjectTo<ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;



                }
                else
                {
                    result.Succeed = false;
                    result.ErrorMessage = "List of schedule null";
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }

        public ResultModel GetAllSlotTypeNotAssignedByDateAndPhysioID(DateTime date, Guid physioID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var schedule = _dbContext.Schedule.Where(s => s.Slot.timeStart.Date == date.Date
                && s.Slot.timeStart.Month == date.Month
                && s.Slot.timeStart.Year == date.Year
                && s.typeOfSlotID == null
                && s.physiotherapistID == physioID
                );
                if (schedule != null)
                {
                    var view = _mapper.ProjectTo<ScheduleModel>(schedule);
                    result.Data = view;
                    result.Succeed = true;
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
