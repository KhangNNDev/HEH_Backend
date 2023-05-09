using AutoMapper;
using Data.DataAccess;
using Data.Entities;
using Data.Model;
using Services.Hubs;
using Data.Utils.Paging;
using Data.Enums;
using Data.Common.PaginationModel;
using Data.DataAccess.Constant;

namespace Services.Core
{
    public interface INotificationService
    {
        ResultModel Get(Guid userId, PagingParam<NotificationSortCriteria> paginationModel);
        Task<ResultModel> Add(NotificationAddModel model);
        Task<ResultModel> SeenNotify(Guid userID);
    }
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _dbContext;
        private readonly INotificationHub _notificationHub;
        private readonly IMapper _mapper;

        public NotificationService(AppDbContext dbContext, INotificationHub notificationHub, IMapper mapper)
        {
            _dbContext = dbContext;
            _notificationHub = notificationHub;
            _mapper = mapper;
        }

        public ResultModel Get(Guid userId, PagingParam<NotificationSortCriteria> paginationModel)
        {
            var result = new ResultModel();
            try
            {
                var notifies = _dbContext.Notification.Where(_ => _.UserId == userId && !_.IsDeleted);

                var paging = new PagingModel(paginationModel.PageIndex, paginationModel.PageSize, notifies.Count());

                notifies = notifies.GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder);
                notifies = notifies.GetWithPaging(paginationModel.PageIndex, paginationModel.PageSize);

                var viewModels = _mapper.ProjectTo<NotificationModel>(notifies).ToList();

                paging.Data = viewModels;

                result.Data = paging;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }
            return result;
        }
        public async Task<ResultModel> Add(NotificationAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var notify = _mapper.Map<NotificationAddModel, Notification>(model);

                await _dbContext.Notification.AddAsync(notify);

                var notifyView = _mapper.Map<Notification, NotificationModel>(notify);

                await _dbContext.SaveChangesAsync();

                await _notificationHub.NewNotification(notifyView, model.UserId + "");

                var newNotifiCount = _dbContext.Notification.Count(_ => _.UserId == model.UserId && !_.IsDeleted && !_.Seen);

                await _notificationHub.NewNotificationCount(int.Parse(newNotifiCount.ToString()), model.UserId + "");

                result.Data = notify.Id;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }
            return result;
        }

        public async Task<ResultModel> SeenNotify(Guid userID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Notification.Where(s => s.UserId == userID).ToList();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        if (item.Seen == false)
                        {
                            item.Seen = true;
                        }
              
                    }
                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = true;
                }
                else
                {
                    result.ErrorMessage = "MedicalRecord" + ErrorMessage.ID_NOT_EXISTED;
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
