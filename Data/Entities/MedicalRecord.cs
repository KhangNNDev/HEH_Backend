using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MedicalRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid medicalRecordID { get; set; }
        public Guid? subProfileID { get; set; }
        [ForeignKey("subProfileID")]
        public virtual SubProfile? SubProfile { get; set; }
        public string problem { get; set; }
        public string difficult { get; set; }
        public string injury { get; set; }
        public string curing { get; set; }
        public string medicine { get; set; }
        public bool isDeleted { get; set; }
        

    }
}
