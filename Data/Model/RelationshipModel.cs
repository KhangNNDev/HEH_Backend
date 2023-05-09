using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class RelationshipCreateModel
    {

        public string relationName { get; set; }
        public bool isDeleted { get; set; }
    }
    public class RelationshipUpdateModel
    {
        public Guid relationId { get; set; }
        public string relationName { get; set; }
        public bool isDeleted { get; set; }
    }
    public class RelationshipModel : RelationshipUpdateModel
    {
        public DateTime DateUpdated = DateTime.Now;
    }
}
