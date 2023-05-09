using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;

namespace Services.Core
{
    public interface IFeedbackService
    {
        ResultModel Add(FeedbackCreateModel model);
        ResultModel Update(FeedbackUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        public FeedbackService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(FeedbackCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<FeedbackCreateModel, Data.Entities.Feedback>(model);
                _dbContext.Feedback.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.Feedback, FeedbackModel>(data);
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
                var data = _dbContext.Feedback.Where(s => s.feedbackID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Feedback, FeedbackModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Feedback" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Feedback.Where(s => s.feedbackID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<FeedbackModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Feedback" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Feedback.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<FeedbackModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }



        public ResultModel Update(FeedbackUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Feedback.Where(s => s.feedbackID == model.feedbackID).FirstOrDefault();
                if (data != null)
                {
                    
                        if (model.scheduleID != null)
                        {
                            data.scheduleID = model.scheduleID;
                        }
                        if (model.ratingStar != null)
                        {
                            data.ratingStar = model.ratingStar;
                        }
                        if (model.comment != null)
                        {
                            data.comment = model.comment;
                        }
        
                    

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Feedback, FeedbackModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Feedback" + ErrorMessage.ID_NOT_EXISTED;
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
