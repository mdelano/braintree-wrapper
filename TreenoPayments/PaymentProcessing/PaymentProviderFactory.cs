using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing.BraintreePayments;

namespace TreenoPayments.PaymentProcessing
{
    class PaymentProviderFactory
    {
        public IPaymentProvider makePaymentProvider()
        {
            return new BraintreePaymentProvider();
        }
    }
}
