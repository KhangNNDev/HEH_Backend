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
    public interface IExerciseResourceService
    {
        ResultModel Add(ExerciseResourceCreateModel model);
        ResultModel Update(ExerciseResourceUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByExerciseDetailID (Guid id);
    }
    public class ExerciseResourceService : IExerciseResourceService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public ExerciseResourceService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ResultModel Add(ExerciseResourceCreateModel model)
        {
            var result = new ResultModel();
            var exerResource = _dbContext.ExerciseResource.Where(s => s.resourceName == model.resourceName && !s.isDeleted).FirstOrDefault();
            try
            {
                if(exerResource != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Tên Tài Nguyên Của Bài Tập Đã Tồn Tại!";
                }
                else
                {
                    var data = _mapper.Map<ExerciseResourceCreateModel, Data.Entities.ExerciseResource>(model);
                    _dbContext.ExerciseResource.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.ExerciseResource, ExerciseResourceModel>(data);
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
                var data = _dbContext.ExerciseResource.Where(s => s.exerciseResourceID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.ExerciseResource, ExerciseResourceModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise Resource" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseResource.Where(s => s.exerciseResourceID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ExerciseResourceModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "ExerciseResource" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseResource.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<ExerciseResourceModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByExerciseDetailID(Guid id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.ExerciseResource.Where(s => s.exerciseDetailID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo< ExerciseResourceModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "ExerciseResource" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ExerciseResourceUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.ExerciseResource.Where(s => s.exerciseResourceID == model.exerciseResourceID).FirstOrDefault();
                if (data != null)
                {
                    if (model.exerciseResourceID != null)
                    {
                        data.resourceName = model.resourceName;
                    }
                    if(model.videoURL!= null) 
                    {
                        data.videoURL = model.videoURL;
                    }
                    if (model.imageURL!= null) 
                    {
                        data.imageURL = model.imageURL;
                    }
                    if (model.isDeleted!= null)
                    {
                        data.isDeleted = model.isDeleted;
                    }
                    if (model.exerciseDetailID != null)
                    {
                        data.exerciseDetailID = (Guid)model.exerciseDetailID;
                    }


                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.ExerciseResource, ExerciseResourceModel>(data);
                }
                else
                {
                    result.ErrorMessage = "ExerciseResource" + ErrorMessage.ID_NOT_EXISTED;
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
