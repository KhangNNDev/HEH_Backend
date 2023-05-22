using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using Data.Entities;

namespace Services.Core
{
    public interface IExerciseDetailService
    {
        ResultModel Add(ExerciseDetailCreateModel model);
        ResultModel Update(ExerciseDetailUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByExerciseID(Guid id);

        Guid TestDI();
    }
    public class ExerciseDetailService : IExerciseDetailService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        public Guid TestDI()
        {
            return id;
        }
        public ExerciseDetailService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(ExerciseDetailCreateModel model)
        {
            var result = new ResultModel();
            var exerDetail = _dbContext.ExerciseDetail.Where(s => s.detailName == model.detailName).FirstOrDefault();
            try
            {
                if (exerDetail != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = " Bài Tập Đã Tồn Tại!";
                }
                var data = _mapper.Map<ExerciseDetailCreateModel, Data.Entities.ExerciseDetail>(model);
                _dbContext.ExerciseDetail.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.ExerciseDetail, ExerciseDetailModel>(data);
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
                var data = _dbContext.ExerciseDetail.Where(s => s.exerciseDetailID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.ExerciseDetail, ExerciseDetailModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise Detail" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseDetail.Where(s => s.exerciseDetailID == id && !s.isDeleted);

                if (data != null)
                {
                    
                    var view = _mapper.ProjectTo< ExerciseDetailModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise Detail" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseDetail.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<ExerciseDetailModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ExerciseDetailUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.ExerciseDetail.Where(s => s.exerciseDetailID == model.exerciseDetailID).FirstOrDefault();
                if (data != null)
                {
                    if (model.exerciseID != null)
                    {
                        data.exerciseID = model.exerciseID;
                    }
                    if (model.detailName != null)
                    {
                        data.detailName = model.detailName;
                    }
                     
                    if (model.set != null)
                    {
                        data.set = model.set;
                    }
                    if (model.description != null)
                    {
                        data.description = model.description;
                    }
                    if (model.isDeleted != null)
                    {
                        data.isDeleted = model.isDeleted;
                    }
                    if (model.favoriteStatus != null)
                    {
                        data.favoriteStatus = model.favoriteStatus; 
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.ExerciseDetail, ExerciseDetailModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Exercise Detail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByExerciseID(Guid id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.ExerciseDetail.Where(s => s.exerciseID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo< ExerciseDetailModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Exercise Detail" + ErrorMessage.ID_NOT_EXISTED;
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
