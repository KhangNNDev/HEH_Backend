using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ExerciseCreateModel
    {
        public string exerciseName { get; set; }
        public Guid categoryID { get; set; }
        public int exerciseTimePerWeek { get; set; }
        public string? iconUrl { get; set; }
        public bool flag { get; set; }
        public bool status { get; set; }
        public bool isDeleted { get; set; }
    }
    public class ExerciseUpdateModel
    {
        public Guid exerciseID { get; set; }
        public Guid categoryID { get; set; }
        public string exerciseName { get; set; }
        public int exerciseTimePerWeek { get; set; }
        public string? iconUrl { get; set; }
        public bool flag { get; set; }
        public bool status { get; set; }
        public bool isDeleted { get; set; }

    }
    public class ExerciseModel : ExerciseUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
