using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Problem
    {
        public Guid problemID { get; set; }
        public Guid? categoryID { get; set; }
        [ForeignKey("categoryID")]
        public virtual Category? Category { get; set; }
        public Guid? medicalRecordID { get; set; }
        [ForeignKey("medicalRecordID")]
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public bool isDeleted { get; set; }
    }
}
