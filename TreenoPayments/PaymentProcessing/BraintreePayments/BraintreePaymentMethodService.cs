using Braintree;
using BraintreePayments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing.BraintreePayments;
using TreenoPayments.PaymentProcessing;

namespace TreenoPayments.PaymentProcessing.BraintreePayments
{
    class BraintreePaymentMethodService : IPaymentMethodService<String, String>
    {
        public String AddPaymentMethod(String customerId, String nonce)
        {
            Result<PaymentMethod> result = BraintreeClient.SANDBOX_GATEWAY.PaymentMethod.Create(new PaymentMethodRequest()
            {
                CustomerId = customerId,
                PaymentMethodNonce = nonce,
                Options = new PaymentMethodOptionsRequest
                {
                    FailOnDuplicatePaymentMethod = true
                }
            });

            BraintreeResponse<PaymentMethod> response = new BraintreeResponse<PaymentMethod>(result);

            return response.getProviderResponse().Target.Token;
        }

        public String ReadPaymentMethod(String paymentMethodToken)
        {
            throw new NotImplementedException();
        }


        public void RemovePaymentMethod(String paymentMethodToken)
        {
            BraintreeClient.SANDBOX_GATEWAY.PaymentMethod.Delete(paymentMethodToken);
        }
    }
}
