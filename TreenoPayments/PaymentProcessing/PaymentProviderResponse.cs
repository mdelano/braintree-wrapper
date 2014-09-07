using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

namespace TreenoPayments.PaymentProcessing
{
    public abstract class PaymentProviderResponse<ProviderResponseType> : ITransactionResponse<ProviderResponseType>
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
