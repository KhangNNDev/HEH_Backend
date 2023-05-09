using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SubProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid profileID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public Guid relationId { get; set; }
        [ForeignKey("relationId")]
        public virtual Relationship Relationship { get; set; }
        //public string profileName { get; set; }
        public string subName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool isDeleted { get; set; }

    }
}
