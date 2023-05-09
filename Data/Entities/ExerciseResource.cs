using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ExerciseResource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid exerciseResourceID { get; set; }
        public Guid exerciseDetailID { get; set; }
        [ForeignKey("exerciseDetailID")]
        public virtual ExerciseDetail ExerciseDetail { get; set; }
        public string resourceName { get; set; }
        public string? videoURL { get; set; }
        public string? imageURL { get; set; }
        public bool isDeleted { get; set; }

    }
}
