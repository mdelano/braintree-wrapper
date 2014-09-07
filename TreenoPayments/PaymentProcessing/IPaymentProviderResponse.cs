using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// Represents a response from a payment provider. 
    /// 
    /// This class provides a standard interface for dealing with responses of varying type from any payment provider
    /// </summary>
    /// <typeparam name="PaymentProviderResponseType">The type that will be returned from the payment provider</typeparam>
    public interface IPaymentProviderResponse<out PaymentProviderResponseType>
    {
        /// <summary>
        /// Determines of the response from the payment provider was successful
        /// </summary>
        /// <returns></returns>
        bool IsSuccess();

        /// <summary>
        /// Gets the message of the response from the payment provider
        /// </summary>
        /// <returns></returns>
        String getResponseMessage();

        /// <summary>
        /// Get's an error map of any erros returned from the payment provider
        /// </summary>
        /// <returns></returns>
        IDictionary<String, String> getErrors();

        /// <summary>
        /// Gets that actual response from the payment provider
        /// </summary>
        /// <returns></returns>
        PaymentProviderResponseType getProviderResponse();
    }
}
