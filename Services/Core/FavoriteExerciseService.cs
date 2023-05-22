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
    public interface IFavoriteExerciseService
    {
        ResultModel Add(FavoriteExerciseCreateModel model);
        ResultModel Update(FavoriteExerciseUpdateModel model);
        ResultModel GetByUserIDAndExerciseID(Guid? id);
        ResultModel GetAll();
        ResultModel DeleteByExerciseDetailIDAndUserID(Guid detailID, Guid userID);

    }
    public class FavoriteExerciseService : IFavoriteExerciseService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        

        
        public FavoriteExerciseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public ResultModel Add(FavoriteExerciseCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<FavoriteExerciseCreateModel, Data.Entities.FavoriteExercise>(model);
                _dbContext.FavoriteExercise.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.FavoriteExercise, FavoriteExerciseModel>(data);
                result.Succeed = true;

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel DeleteByExerciseDetailIDAndUserID(Guid detailID, Guid userID)
        {
            ResultModel result = new ResultModel();
            try
            {   
                var data = _dbContext.FavoriteExercise.Where(
                s => s.exerciseDetailID == detailID
                && s.userID == userID  
                && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    _dbContext.FavoriteExercise.Remove(data);
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.FavoriteExercise, FavoriteExerciseModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "FavoriteExercise" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByUserIDAndExerciseID(Guid? id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.FavoriteExercise.Where(s => s.favoriteExerciseID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<FavoriteExerciseModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "FavoriteExercise" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.FavoriteExercise.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<FavoriteExerciseModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(FavoriteExerciseUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.FavoriteExercise.Where(s => s.favoriteExerciseID == model.favoriteExerciseID).FirstOrDefault();
                if (data != null)
                {
                    if (model.exerciseDetailID != null)
                    {
                    
                        data.exerciseDetailID = model.exerciseDetailID;
                    }
                    if (model.userID != null)
                    {
                        data.userID = model.userID;
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.FavoriteExercise, FavoriteExerciseModel>(data);
                }
                else
                {
                    result.ErrorMessage = "FavoriteExercise" + ErrorMessage.ID_NOT_EXISTED;
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
