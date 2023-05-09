using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TypeOfSlot
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid typeOfSlotID { get; set; }
        public string typeName { get; set; }
        public float price { get; set; }
        public bool isDeleted { get; set; }
    }
}
