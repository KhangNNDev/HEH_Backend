
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
    public interface ITypeOfSlotService
    {
        ResultModel Add(TypeOfSlotCreateModel model);
        ResultModel Update(TypeOfSlotUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);
        ResultModel GetByTypeName(string typeName);

    }
    public class TypeOfSlotService : ITypeOfSlotService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public TypeOfSlotService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public ResultModel Add(TypeOfSlotCreateModel model)
        {
            var result = new ResultModel();
            var typeName = _dbContext.TypeOfSlot.Where(s => s.typeName == model.typeName && s.isDeleted == false).FirstOrDefault();
            try
            {   
                if(typeName!= null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Type name đã tồn tại!";
                }
                else
                {
                    var data = _mapper.Map<TypeOfSlotCreateModel, Data.Entities.TypeOfSlot>(model);
                    _dbContext.TypeOfSlot.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.TypeOfSlot, TypeOfSlotModel>(data);
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
                
                var data = _dbContext.TypeOfSlot.Where(s => s.typeOfSlotID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.TypeOfSlot, TypeOfSlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "TypeOfSlot" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.TypeOfSlot.Where(s => s.typeOfSlotID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.TypeOfSlot, TypeOfSlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "TypeOfSlot" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.TypeOfSlot.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<TypeOfSlotModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetByTypeName(string typeName)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.TypeOfSlot.Where(s => s.typeName == typeName && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.TypeOfSlot, TypeOfSlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "TypeOfSlot" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(TypeOfSlotUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.TypeOfSlot.Where(s => s.typeOfSlotID == model.typeOfSlotID).FirstOrDefault();
                if (data != null)
                {
                    
                        if (model.typeName != null)
                        {
                            data.typeName = model.typeName;
                        }
                        if (model.price != null)
                        {
                            data.price = model.price;
                        }
                        if (model.isDeleted != null)
                        {
                            data.isDeleted = model.isDeleted;
                        }
                    
                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.TypeOfSlot, TypeOfSlotModel>(data);
                }
                else
                {
                    result.ErrorMessage = "TypeOfSlot" + ErrorMessage.ID_NOT_EXISTED;
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
