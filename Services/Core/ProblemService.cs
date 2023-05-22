using AutoMapper;
using Data.DataAccess.Constant;
using Data.DataAccess;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Services.Core
{
    public interface IProblemService
    {
        ResultModel Add(ProblemCreateModel model);
        ResultModel Update(ProblemUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel GetByMedicalRecordID(Guid medicalRecordID);
        ResultModel Delete(Guid id);


    }
    public class ProblemService : IProblemService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public ProblemService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(ProblemCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<ProblemCreateModel, Problem>(model);
                _dbContext.Problem.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Problem, ProblemModel>(data);
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

                var data = _dbContext.Problem.Where(s => s.problemID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    _dbContext.Problem.Remove(data);
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Problem, ProblemModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Problem" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Problem.Where(s => s.problemID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ProblemModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Problem" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Problem.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<ProblemModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByMedicalRecordID(Guid medicalRecordID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Problem.Where(s => s.medicalRecordID == medicalRecordID && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<ProblemModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Problem" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ProblemUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Problem.Where(s => s.problemID == model.problemID).FirstOrDefault();
                if (data != null)
                {

                    if (model.categoryID!= null)
                    {
                        data.categoryID = model.categoryID;
                    }

                    if (model.medicalRecordID != null)
                    {
                        data.medicalRecordID = model.medicalRecordID;
                    }


                    //if (model.price != null)
                    //{
                    //    data.price = model.price;
                    //}

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Problem, ProblemModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Problem" + ErrorMessage.ID_NOT_EXISTED;
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
