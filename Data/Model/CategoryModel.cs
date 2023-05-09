using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class CategoryCreateModel
    {

        public string categoryName { get; set; }
        public string description { get; set; }
        public string? iconUrl { get; set; }
        public bool isDeleted { get; set; }
    }
    public class CategoryUpdateModel
    {
        public Guid categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string? iconUrl { get; set; }
        public bool isDeleted { get; set; }

    }
    public class CategoryModel : CategoryUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
