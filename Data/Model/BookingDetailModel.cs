using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BookingDetailCreateModel
    {

        public Guid? bookingScheduleID { get; set; }
        public string? videoCallRoom { get; set; }
        public bool status { get; set; }
        public int? longtermStatus { get; set; }
        public int? shorttermStatus { get; set; }
    }
    public class BookingDetailUpdateModel
    {
        public Guid bookingDetailID { get; set; }
  
    
        public Guid? bookingScheduleID { get; set; }
        public string? videoCallRoom { get; set; }
        public bool status { get; set; }
        public int? longtermStatus { get; set; }
        public int? shorttermStatus { get; set; }

    }
    public class BookingDetailModel : BookingDetailUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public BookingScheduleModel? BookingSchedule { get; set; }
    }
}