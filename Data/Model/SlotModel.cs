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
    public class SlotCreateModel
    {
        public string? slotName { get; set; }
        //public Guid? typeOfSlotID { get; set; }
        //public Guid physiotherapistID { get; set; }
        //public Guid totalScheduleID { get; set; }
        //public Guid exerciseDetailID { get; set; }
        [Required]
        public DateTime timeStart { get; set; }
        [Required]
        public DateTime timeEnd { get; set; }
        //public TimeOnly duaration { get; set; }
  
        [Required]

        public bool available { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SlotUpdateModel
    {
        public Guid slotID { get; set; }
        public string? slotName { get; set; }
        [Required]
        public DateTime timeStart { get; set; }
        [Required]
        public DateTime timeEnd { get; set; }
        //public TimeOnly duaration { get; set; }

        [Required]
        public bool available { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SlotModel : SlotUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }

}


