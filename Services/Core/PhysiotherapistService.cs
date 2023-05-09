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
    public interface IPhysiotherapistService
    {
        ResultModel Add(PhysiotherapistCreateModel model);
        ResultModel Update(PhysiotherapistUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel getAllActivePhysiotherapist ();
        ResultModel GetPhysiotherapistByUserID(Guid userId);
        Guid TestDI();
    }
    public class PhysiotherapistService : IPhysiotherapistService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        public Guid TestDI()
        {
            return id;
        }
        public PhysiotherapistService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(PhysiotherapistCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<PhysiotherapistCreateModel, Data.Entities.Physiotherapist>(model);
                _dbContext.Physiotherapist.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.Physiotherapist, PhysiotherapistModel>(data);
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
                var data = _dbContext.Physiotherapist.Where(s => s.physiotherapistID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Physiotherapist, PhysiotherapistModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Physiotherapist Detail" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Physiotherapist.Where(s => s.physiotherapistID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<PhysiotherapistModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "PhysiotherapistDetail" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Physiotherapist.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<PhysiotherapistModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(PhysiotherapistUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Physiotherapist.Where(s => s.physiotherapistID == model.physiotherapistID).FirstOrDefault();
                if (data != null)
                {
                    //if (model.physiotherapistID != null)
                    //{
                    //    data.userID = model.userID;
                   // }
                   if (model.scheduleStatus != null)
                    {
                        data.scheduleStatus = model.scheduleStatus;
                    }  
                    if (model.specialize != null)
                    {
                        data.specialize = model.specialize;
                    }
                    if (model.skill != null)
                    {
                        data.skill = model.skill;
                    }

                    //if (model.workingStatus != null)
                    //{
                    //    data.workingStatus = model.workingStatus;
                    //}
                    if (model.userID!= null)
                    {
                        data.userID = (Guid)model.userID;
                    }



                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Physiotherapist, PhysiotherapistModel>(data);
                }
                else
                {
                    result.ErrorMessage = "PhysiotherapistDetail" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel getAllActivePhysiotherapist()
        {
            ResultModel result= new ResultModel();
            try
            {
                var data = _dbContext.Physiotherapist.Where(s => s.isDeleted != true 
         
                && s.scheduleStatus == 1);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<PhysiotherapistModel>(data);
                    result.Succeed = true;
                    result.Data = view;

                }
                else
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Physiotherapist" + ErrorMessage.GET_ALL_NULL;
                }
                
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message: e.Message;
            }
            return result;
        }

        public ResultModel GetPhysiotherapistByUserID(Guid userId)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Physiotherapist.Where(s => s.userID == userId && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<PhysiotherapistModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "PhysiotherapistDetail" + ErrorMessage.ID_NOT_EXISTED;
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
