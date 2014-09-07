using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing.BraintreePayments;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// The purpose of this class is to provide an abstraction layer for 
    /// creating payment providers to avoid substantial refactoring if 
    /// the payment provider had to change
    /// </summary>
    class PaymentProviderFactory
    {
        public IPaymentProvider makePaymentProvider()
        {
            return new BraintreePaymentProvider(); // At the moment this is the only payment provider we deal with so we'll just return one.
        }
    }
}
