using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Physiotherapist
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid physiotherapistID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        
        public string specialize { get; set; }
        public string skill { get; set; }
        //public int schedulingStatus { get; set; }
        public int scheduleStatus { get; set; }
        public bool isDeleted { get; set; }
    }
}
