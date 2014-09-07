using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public class Customer
    {
        public String CustomerId { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }
}
