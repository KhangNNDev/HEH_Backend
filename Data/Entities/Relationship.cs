using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Relationship
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid relationId { get; set; }
        public string relationName { get; set; }
        public bool isDeleted { get; set; }
    }
}
