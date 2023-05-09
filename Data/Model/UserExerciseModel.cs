using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class UserExerciseCreateModel
    {
        public Guid userID { get; set; }
        public Guid exerciseDetailID { get; set; }
        public DateTime duarationTime { get; set; }
        public bool status { get; set; }
        public bool isDeleted
        {
            get; set;
        }

    }
    public class UserExerciseUpdateModel
    {
        public Guid userExerciseID { get; set; }
        public Guid exerciseDetailID { get; set; }
        public DateTime duarationTime { get; set; }
        public bool status { get; set; }
        public bool isDeleted { get; set; }

    }
    public class UserExerciseModel : UserExerciseUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserModel? User { get; set; }
        public ExerciseDetailModel? ExerciseDetail { get; set; }
    }
}
