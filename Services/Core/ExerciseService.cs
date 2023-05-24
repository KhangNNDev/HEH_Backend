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
    public interface IExerciseService
    {
        ResultModel Add(ExerciseCreateModel model);
        ResultModel Update(ExerciseUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByCategoryID(Guid categoryID);

    }
    public class ExerciseService : IExerciseService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        
        
        public ExerciseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public ResultModel Add(ExerciseCreateModel model)
        {
            var result = new ResultModel();
            var exerName = _dbContext.Exercise.Where(s => s.exerciseName == model.exerciseName && !s.isDeleted).FirstOrDefault();
            try
            {
                if(exerName != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Bài Tập Đã Tồn Tại!";
                }
                else
                {
                    var data = _mapper.Map<ExerciseCreateModel, Data.Entities.Exercise>(model);
                    _dbContext.Exercise.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.Exercise, ExerciseModel>(data);
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
                var data = _dbContext.Exercise.Where(s => s.exerciseID == id && !s.isDeleted ).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Exercise, ExerciseModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Exercise.Where(s => s.exerciseID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ExerciseModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Exercise.Where(s => s.isDeleted != true);
               
                var view = _mapper.ProjectTo<ExerciseModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByCategoryID(Guid categoryID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Exercise.Where(s => s.categoryID == categoryID && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ExerciseModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ExerciseUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Exercise.Where(s => s.exerciseID == model.exerciseID ).FirstOrDefault();
                if (data != null)
                {
                    if (model.exerciseID != null)
                    {
                        data.exerciseName = model.exerciseName;
                    }
                    if (model.exerciseTimePerWeek != null)
                    {
                        data.exerciseTimePerWeek = model.exerciseTimePerWeek;
                    }
                    if (model.flag != null)
                    {
                        data.flag = model.flag;
                    }
                    if (model.status != null)
                    {
                        data.status = model.status;
                    }
                    if (model.iconUrl != null)
                    {
                        data.iconUrl = model.iconUrl;
                    }

                    if (model.categoryID != null)
                    {
                        data.categoryID = model.categoryID;
                    }
                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Exercise, ExerciseModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Exercise" + ErrorMessage.ID_NOT_EXISTED;
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
