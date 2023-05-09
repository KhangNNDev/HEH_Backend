using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid scheduleID { get; set; }
        public Guid slotID { get; set; }
        [ForeignKey("slotID")]
        public virtual Slot Slot { get; set; }
        public Guid physiotherapistID { get; set; }
        [ForeignKey("physiotherapistID")]
        public virtual Physiotherapist PhysiotherapistDetail { get; set; }
        public Guid? typeOfSlotID { get; set; }
        [ForeignKey("typeOfSlotID")]
        public virtual TypeOfSlot? TypeOfSlot { get; set; }
        public string? description { get; set; }
        public bool physioBookingStatus { get; set; }
        //public DateTime day { get; set; }
    }
}
