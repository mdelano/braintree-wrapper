using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

namespace BraintreePayments
{
    public class BraintreeResponse<ProviderResponseType> : PaymentProviderResponse<Result<ProviderResponseType>>
    {
        Result<ProviderResponseType> Response;

        public BraintreeResponse() { }

        public BraintreeResponse(Result<ProviderResponseType> transactionResponse)
        {
            Response = transactionResponse;
        }

        public override bool IsSuccess()
        {
            return Response.IsSuccess();
        }

        public override String getResponseMessage()
        {
            return Response.Message;
        }
        public override IDictionary<String, String> getErrors()
        {
            IDictionary<String, String> errors = new Dictionary<String, String>();

            if (Response.Errors != null)
            {
                if (Response.Errors.All() != null)
                {
                    foreach (ValidationError validationError in Response.Errors.All())
                    {
                        errors.Add(validationError.Attribute, validationError.Message);
                    }
                }
            }

            return errors;
        }

        public override Result<ProviderResponseType> getProviderResponse()
        {
            return Response;
        }
    }
}
