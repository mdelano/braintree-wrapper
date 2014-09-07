using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public interface ITransactionResponse<out PaymentProviderResponseType>
    {
        bool IsSuccess();
        String getResponseMessage();
        IDictionary<String, String> getErrors();
        PaymentProviderResponseType getProviderResponse();
    }
}
