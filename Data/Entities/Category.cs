using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Category 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string? iconUrl { get; set; }
        public bool isDeleted { get; set; }
    }
}
