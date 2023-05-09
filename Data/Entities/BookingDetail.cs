using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BookingDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid bookingDetailID { get; set; }
        public Guid? bookingScheduleID { get; set; }
        [ForeignKey("bookingScheduleID")]
        public BookingSchedule? bookingSchedule { get; set; }
        public string? videoCallRoom { get; set; }
        public int? longtermStatus { get; set; }
        public int? shorttermStatus { get; set; }
    }
}
