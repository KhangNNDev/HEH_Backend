using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Feedback 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid feedbackID { get; set; }
        public Guid scheduleID { get; set; }
        [ForeignKey("scheduleID")]
        public virtual Schedule Schedule { get; set; }
        public string? comment { get; set; }
        public int? ratingStar { get; set; }
        public bool isDeleted { get; set; }
    }
}
