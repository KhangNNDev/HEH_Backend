using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class PaymentModel
    {

        public string orderId { get; set; }
        public long amount { get; set; }
        public string email { get; set; }
    }
}
