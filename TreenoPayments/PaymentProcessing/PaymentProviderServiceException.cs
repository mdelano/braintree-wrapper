using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    [Serializable] 
    class PaymentProviderServiceException : Exception
    {
        public Object PaymentProviderExceptionObject;

        public PaymentProviderServiceException() : base() { }
        public PaymentProviderServiceException(String Message) : base(Message) { }
        public PaymentProviderServiceException(String Message, Object PaymentProviderExceptionObject) : base(Message) {
            this.PaymentProviderExceptionObject = PaymentProviderExceptionObject;
        }
    }
}
