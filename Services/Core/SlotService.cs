using AutoMapper;
using Data.DataAccess;
using Data.DataAccess.Constant;
using Data.Entities;
using Data.Model;

namespace Services.Core
{
    public interface ISlotService
    {
        ResultModel Add(SlotCreateModel model);
        ResultModel AddLongTermSlotByPhysioID(SlotCreateModel model, Guid physioID);

        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel Update(SlotUpdateModel model, Guid physioID);
        ResultModel GetShortTermSlotByDateAndPhysioID(DateTime date, Guid physioID);
        ResultModel GetByDateAndTypeOfSlot(DateTime date, string typeOfSlot);

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
            

            try
            {
                    //Staff Tạo slot không được trùng với slot ngắn hạn nhưng được trùng với slot dài hạn
                    var allLongTermSlot = _dbContext.Schedule.Where(
                        s => s.TypeOfSlot.typeName == "Trị liệu dài hạn"
                        ).ToList();
                    List<Guid?> longTermSlotID = new List<Guid?>();
                    foreach (var item in allLongTermSlot)
                    {
                        longTermSlotID.Add(item.slotID);
                    }
                    var allSlotShortTerm = _dbContext.Slot.Where(
                    s => s.timeStart.Year == model.timeStart.Year
                    && s.timeStart.Month == model.timeStart.Month
                    && s.timeStart.Day == model.timeStart.Day
                    && !longTermSlotID.Contains(s.slotID)
                    ).ToList();
                    List<Slot>? listSlotDuplicate = new List<Slot>();
                    allSlotShortTerm.ForEach(slot =>
                        {
                            int startCompareStart = DateTime.Compare(model.timeStart, slot.timeStart);
                            int startCompareEnd = DateTime.Compare(model.timeStart, slot.timeEnd);
                            int endCompareStart = DateTime.Compare(model.timeEnd, slot.timeStart);
                            int endCompareEnd = DateTime.Compare(model.timeEnd, slot.timeEnd);
                            
                            if ((startCompareStart >= 0 && startCompareEnd <= 0) || (startCompareStart < 0 && endCompareStart >= 0))
                            {
                                listSlotDuplicate.Add(slot);
                            }
                        }
                    );
                    if (listSlotDuplicate.Count > 0)
                    {
                        result.Succeed = false;
                        result.Data = listSlotDuplicate;
                        result.ErrorMessage = "Thời gian bị trùng với những slot trước";
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
                var data = _dbContext.Slot.Where(s => s.slotID == id && !s.isDeleted);
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
                var data = _dbContext.Slot.Where(s => s.isDeleted != true);
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
            //get all slot của những chuyên viên mà chưa có ai đăng ký 
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

        public ResultModel GetShortTermSlotByDateAndPhysioID(DateTime date, Guid physioID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var scheduleRegistered = _dbContext.Schedule.Where(s => s.physiotherapistID == physioID ).ToList();
                List<Guid?> listSlotID = new List<Guid?>();
                if (scheduleRegistered.Count > 0)
                {

                    foreach (var schedule in scheduleRegistered)
                    {
                        listSlotID.Add(schedule.slotID);
                    }
                }
                var data = _dbContext.Slot.Where(s => !listSlotID.Contains(s.slotID)
                && s.timeStart.Year == date.Year 
                && s.timeStart.Month == date.Month 
                && s.timeStart.Day == date.Day
                && !s.slotName.Contains("Trị Liệu dài hạn")
                && !s.isDeleted).OrderBy(x => x.timeStart.Hour);

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



        public ResultModel AddLongTermSlotByPhysioID(SlotCreateModel model, Guid physioID)
        {
            var result = new ResultModel();
            try
            {
                //Chuyên viên Tạo slot dài hạn không được trùng với những slot slot ngắn hạn và dài hạn mà chuyên viên đã đăng ký

                var slotRegistered = _dbContext.Schedule.Where(
                    s => s.Slot.timeStart.Year == model.timeStart.Year
                    && s.Slot.timeStart.Month == model.timeStart.Month
                    && s.Slot.timeStart.Day == model.timeStart.Day
                    && s.physiotherapistID == physioID
                    );
                if (slotRegistered != null)
                {
                    var slotData = _mapper.ProjectTo<ScheduleModel>(slotRegistered).ToList();

                    List<SlotModel>? listSlotDuplicate = new List<SlotModel>();
                    slotData.ForEach(Schedule =>
                    {
                        int startCompareStart = DateTime.Compare(model.timeStart, Schedule.Slot.timeStart);
                        int startCompareEnd = DateTime.Compare(model.timeStart, Schedule.Slot.timeEnd);
                        int endCompareStart = DateTime.Compare(model.timeEnd, Schedule.Slot.timeStart);
                        int endCompareEnd = DateTime.Compare(model.timeEnd, Schedule.Slot.timeEnd);

                        if ((startCompareStart >= 0 && startCompareEnd <= 0) || (startCompareStart < 0 && endCompareStart >= 0))
                        {
                            listSlotDuplicate.Add(Schedule.Slot);
                        }
                    }
                        );
                    if (listSlotDuplicate.Count > 0)
                    {
                        result.Succeed = false;
                        result.Data = listSlotDuplicate;
                        result.ErrorMessage = "Thời gian bị trùng với những slot trước";
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
       
                 

            }
            catch (Exception e)
            {

                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(SlotUpdateModel model, Guid physioID)
        {
            var result = new ResultModel();
            try
            {
                //Chuyên viên update slot dài hạn không được trùng với những slot slot ngắn hạn và dài hạn mà chuyên viên đã đăng ký

                var slotRegistered = _dbContext.Schedule.Where(
                    s => s.Slot.timeStart.Year == model.timeStart.Year
                    && s.Slot.timeStart.Month == model.timeStart.Month
                    && s.Slot.timeStart.Day == model.timeStart.Day
                    && s.physiotherapistID == physioID
                    && s.slotID != model.slotID
                    );
                if (slotRegistered != null)
                {
                    var slotData = _mapper.ProjectTo<ScheduleModel>(slotRegistered).ToList();
                    if (model.timeStart != null && model.timeEnd != null)
                    {
                        List<SlotModel>? listSlotDuplicate = new List<SlotModel>();
                        slotData.ForEach(Schedule =>
                        {
                            int startCompareStart = DateTime.Compare(model.timeStart, Schedule.Slot.timeStart);
                            int startCompareEnd = DateTime.Compare(model.timeStart, Schedule.Slot.timeEnd);
                            int endCompareStart = DateTime.Compare(model.timeEnd, Schedule.Slot.timeStart);
                            int endCompareEnd = DateTime.Compare(model.timeEnd, Schedule.Slot.timeEnd);

                            if ((startCompareStart >= 0 && startCompareEnd <= 0) || (startCompareStart < 0 && endCompareStart >= 0))
                            {
                                listSlotDuplicate.Add(Schedule.Slot);
                            }
                        }
                            );
                        if (listSlotDuplicate.Count > 0)
                        {
                            result.Succeed = false;
                            result.Data = listSlotDuplicate;
                            result.ErrorMessage = "Thời gian bị trùng với những slot trước";
                        }
                        else
                        {
                            var data = _dbContext.Slot.Where(s => s.slotID == model.slotID).FirstOrDefault();
                            data.timeStart = model.timeStart;
                            data.timeEnd = model.timeEnd;
                            if (model.available != null)
                            {
                                data.available = model.available;
                            }
                            if (model.slotName != null)
                            {
                                data.slotName = model.slotName;
                            }
                            var view = _mapper.Map< Data.Entities.Slot, SlotModel>(data);
         
                            _dbContext.SaveChanges();
                            result.Data = view;
                            result.Succeed = true;
                        }
                    }
                  
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
