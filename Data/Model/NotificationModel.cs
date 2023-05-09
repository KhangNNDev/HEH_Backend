using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class NotificationModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public bool Seen { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }

        public Guid UserId { get; set; }

    }

    public class NotificationAddModel
    {
        public string Action { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }

}
