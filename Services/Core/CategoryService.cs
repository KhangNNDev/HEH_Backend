
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
    public interface ICategoryService
    {
        ResultModel Add(CategoryCreateModel model);
        ResultModel Update(CategoryUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

        Guid TestDI();
    }
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        public Guid TestDI()
        {
            return id;
        }
        public CategoryService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(CategoryCreateModel model)
        {
            var result = new ResultModel();
            var cateName = _dbContext.Category.Where(s => s.categoryName == model.categoryName).FirstOrDefault();
            try
            {
                if(cateName != null)
                {
                    result.Succeed = false;
                    result.ErrorMessage = "Category Name Đã Tồn Tại!";
                }
                else
                {
                    var data = _mapper.Map<CategoryCreateModel, Data.Entities.Category>(model);
                    _dbContext.Category.Add(data);
                    _dbContext.SaveChanges();
                    result.Data = _mapper.Map<Data.Entities.Category, CategoryModel>(data);
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
                var data = _dbContext.Category.Where(s => s.categoryID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Category, CategoryModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Category" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Category.Where(s => s.categoryID == id && !s.isDeleted);
                if (data != null)
                {
                    var view = _mapper.ProjectTo<CategoryModel>(data).FirstOrDefault();
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Category" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Category.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<CategoryModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(CategoryUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Category.Where(s => s.categoryID == model.categoryID).FirstOrDefault();
                if (data != null)
                {
                    if (model.categoryID != null)
                    {

                        data.categoryName = model.categoryName;
                    }
                    if (model.description != null)
                    {
                        data.description = model.description;
                    }
                    if (model.isDeleted != null)
                    {
                        data.isDeleted = model.isDeleted;
                    }
                    if (model.iconUrl!= null)
                    {
                        data.iconUrl = model.iconUrl;
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Category, CategoryModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Category" + ErrorMessage.ID_NOT_EXISTED;
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
