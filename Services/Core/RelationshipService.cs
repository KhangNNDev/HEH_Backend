
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using Data.Model;

namespace Services.Core
{
    public interface IRelationshipService
    {
        ResultModel Add(RelationshipCreateModel model);
        ResultModel Update(RelationshipUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByRelationName(String relationName);

    }
    public class RelationshipService : IRelationshipService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public RelationshipService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(RelationshipCreateModel model)
        {
            var result = new ResultModel();
            var relaName = _dbContext.Relationship.Where(s => s.relationName == model.relationName).FirstOrDefault();
            try
            {   
                if(relaName != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Mối Quan Hệ Đã Tồn Tại!";
                }
                else
                {
                    var data = _mapper.Map<RelationshipCreateModel, Data.Entities.Relationship>(model);
                    _dbContext.Relationship.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.Relationship, RelationshipModel>(data);
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

                var data = _dbContext.Relationship.Where(s => s.relationId == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Relationship, RelationshipModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Relationship" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Relationship.Where(s => s.relationId == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<RelationshipModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Relationship" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Relationship.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<RelationshipModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByRelationName(string relationName)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Relationship.Where(s => s.relationName == relationName && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<RelationshipModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Relationship" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(RelationshipUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Relationship.Where(s => s.relationId == model.relationId).FirstOrDefault();
                if (data != null)
                {
                    if (model.relationName != null)
                    {
                        data.relationName = model.relationName;
             
                    }
                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Relationship, RelationshipModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Relationship" + ErrorMessage.ID_NOT_EXISTED;
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
