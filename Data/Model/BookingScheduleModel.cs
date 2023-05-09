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
    public class BookingScheduleCreateModel
    {


        public Guid userID { get; set; }
        public Guid? profileID { get; set; }
        public Guid? scheduleID { get; set; }
        public DateTime dateBooking { get; set; }
        public DateTime timeBooking { get; set; }
        public bool status { get; set; }
    }
    public class BookingScheduleUpdateModel
    {
        public Guid bookingScheduleID { get; set; }
        public Guid? userID { get; set; }
        
        public Guid? profileID { get; set; }
        public Guid? scheduleID { get; set; }
        public DateTime dateBooking { get; set; }
        public DateTime timeBooking { get; set; }
        public bool status { get; set; }

    }
    public class BookingScheduleModel : BookingScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserModel? User { get; set; }
        public SubProfileModel? SubProfile { get; set; }
        public ScheduleModel? Schedule { get; set; }
    }
}