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
    public class PhysiotherapistCreateModel
    {

        public Guid? userID { get; set; }
        [Required]
        public string specialize { get; set; }
        [Required]
        public string skill { get; set; }
        public int scheduleStatus { get; set; }

        public bool isDeleted  { get; set; }
    }
    public class PhysiotherapistUpdateModel
    {
        public Guid physiotherapistID { get; set; }
        public Guid? userID { get; set; }
        
        [Required]
        public string specialize { get; set; }
        [Required]
        public string skill { get; set; }
        public int scheduleStatus { get; set; }
        public bool isDeleted { get; set; }

    }
    public class PhysiotherapistModel : PhysiotherapistUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserModel? user { get; set; }
    }
}

