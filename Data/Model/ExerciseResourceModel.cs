using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ExerciseResourceCreateModel
    {
        public Guid exerciseDetailID { get; set; }
        public string? resourceName { get; set; }
        public string? videoURL { get; set; }
        public string? imageURL { get; set; }

        public bool isDeleted { get; set; }
    }
    public class ExerciseResourceUpdateModel
    {
        public Guid exerciseResourceID { get; set; }
        public Guid? exerciseDetailID { get; set; }
        public string? resourceName { get; set; }

        public string? videoURL { get; set; }

        public string? imageURL { get; set; }

        public bool isDeleted { get; set; }
    }
    public class ExerciseResourceModel : ExerciseResourceUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public ExerciseDetailModel? ExerciseDetail { get; set; }
    }
}