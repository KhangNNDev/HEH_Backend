using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Slot
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid slotID { get; set; }
        public string? slotName { get; set; }

        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        
        public bool available { get; set; }
        public bool isDeleted { get; set; }
    }
}
