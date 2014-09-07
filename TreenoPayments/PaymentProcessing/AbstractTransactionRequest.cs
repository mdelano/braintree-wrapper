using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public abstract class AbstractTransactionRequest : ITransactionRequest
    {
        public String OrderId { get; set; }
        public Decimal Amount { get; set; }
        public Customer Customer { get; set; }
        public Address BillingAddress { get; set; }

        protected AbstractTransactionRequest(Decimal amount){
            Amount = amount;
        }
    }
}
