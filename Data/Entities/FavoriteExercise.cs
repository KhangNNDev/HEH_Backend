using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FavoriteExercise 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid favoriteExerciseID { get; set; }
        public Guid favoriteExerciseID { get; set; }
        public Guid exerciseDetailID { get; set; }
        [ForeignKey("exerciseDetailID")]
        public virtual ExerciseDetail ExerciseDetail { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public bool isDeleted { get; set; }
    }
}
