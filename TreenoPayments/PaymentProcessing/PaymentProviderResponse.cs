using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// A generic response that will wrap the response from a payment provider 
    /// so that we can deal will something consistent in our payment code
    /// </summary>
    /// <typeparam name="PaymentProviderResponseType">The type that will be returned from the payment provider</typeparam>
    public abstract class PaymentProviderResponse<ProviderResponseType> : IPaymentProviderResponse<ProviderResponseType>
    {
        ProviderResponseType Response;

        public PaymentProviderResponse() { }

        public PaymentProviderResponse(ProviderResponseType transactionResponse)
        {
            Response = transactionResponse;
        }

        public abstract bool IsSuccess();

        public abstract String getResponseMessage();

        public abstract IDictionary<String, String> getErrors();

        public abstract ProviderResponseType getProviderResponse();
    }
}
