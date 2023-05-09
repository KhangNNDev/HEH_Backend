using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class TypeOfSlotCreateModel
    {
        public string typeName { get; set; }
        public float price { get; set; }
        public bool isDeleted { get; set; }
    }
    public class TypeOfSlotUpdateModel
    {
        public Guid typeOfSlotID { get; set; }
        public string typeName { get; set; }
        public float price { get; set; }
        public bool isDeleted { get; set; }

    }
    public class TypeOfSlotModel : TypeOfSlotUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
