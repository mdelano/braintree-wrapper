using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public interface IPaymentMethodService<PaymentMethodRequestType, PaymentMethodResponseType>
    {
        String AddPaymentMethod(String customerId, PaymentMethodRequestType paymentMethod);
        PaymentMethodResponseType ReadPaymentMethod(String paymentMethodToken);
        void RemovePaymentMethod(String paymentMethodToken);
    }
}
