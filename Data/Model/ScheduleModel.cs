using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ScheduleCreateModel
    {
        [Required]
        public Guid slotID { get; set; }
        [Required]
        public Guid physiotherapistID { get; set; }
        public Guid? typeOfSlotID { get; set; }

        public string? description { get; set; }
        public bool physioBookingStatus { get; set; }
        //public DateTime day { get; set; }
    }
    public class ScheduleUpdateModel
    {
        public Guid scheduleID { get; set; }
        [Required]
        public Guid slotID { get; set; }
        [Required]
        public Guid physiotherapistID { get; set; }
  
        
        public Guid? typeOfSlotID { get; set; }
        public string? description { get; set; }
        public bool physioBookingStatus { get; set; }

        //public DateTime day { get; set; }
    }
    public class ScheduleModel : ScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public SlotModel? Slot { get; set; }
        public  PhysiotherapistModel? PhysiotherapistDetail { get; set; }
        public TypeOfSlotModel? TypeOfSlot { get; set; }
        
    }
}