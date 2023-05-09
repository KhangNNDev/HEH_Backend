using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : IdentityUser<Guid>
    {
/*        public Guid depositID { get; set; }
        [ForeignKey("depositID")]
        public virtual Deposit Deposit { get; set; }
        public Guid symptonsID { get; set; }
        [ForeignKey("symptonsID")]
        public virtual MedicalRecord MedicalRecord { get; set; }*/
        

        [Column(TypeName = "varchar(1000)")]
        public string firstName { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string? lastName { get; set; }
        public string address { get; set; }
        public string? image { get; set; }
        public DateTime dob { get; set; }
        public bool gender { get; set; }
        public bool bookingStatus { get; set; }
        public bool banStatus { get; set; }
        public Guid? roleID { get; set; }
        [ForeignKey("roleID")]
        public virtual Role? Role { get; set; }
    }
}
