using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class SubProfileCreateModel
    {

        public Guid userID { get; set; }
        public Guid relationId { get; set; }
        public string? subName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SubProfileUpdateModel
    {
        public Guid profileID { get; set; }
        public Guid userID { get; set; }
        
        public Guid relationId { get; set; }

        public string? subName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SubProfileModel : SubProfileUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserModel? User { get; set; }
        public RelationshipModel? Relationship { get; set; }
    }
}