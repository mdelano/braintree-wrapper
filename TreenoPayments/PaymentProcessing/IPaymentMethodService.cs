using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// The payment method service should support adding customer payment methods such as 
    /// credit cards for subsequent reuse by subscriptions or direct purchases
    /// </summary>
    /// <typeparam name="PaymentMethodRequestType">This should be the type that will be sent to 
    /// the payment provider when creating a new payment method</typeparam>
    /// <typeparam name="PaymentMethodResponseType">This should be the type that will be 
    /// returned from the payment provider when getting payment methods</typeparam>
    public interface IPaymentMethodService<PaymentMethodRequestType, PaymentMethodResponseType>
    {
        /// <summary>
        /// Create a new payment method at the payment provider
        /// </summary>
        /// <param name="customerId">The id of the customer to which the payment method belongs</param>
        /// <param name="paymentMethod">The payment method to save at the payment provider</param>
        /// <returns></returns>
        String AddPaymentMethod(String customerId, PaymentMethodRequestType paymentMethod);

        /// <summary>
        /// Get an existing payment method from the payment provider
        /// </summary>
        /// <param name="paymentMethodToken">The identifier of the pamynet method</param>
        /// <returns></returns>
        PaymentMethodResponseType ReadPaymentMethod(String paymentMethodToken);

        /// <summary>
        /// Delete an existing payment method at the payment provider
        /// </summary>
        /// <param name="paymentMethodToken">The identifier of the pamynet method</param>
        void RemovePaymentMethod(String paymentMethodToken);
    }
}
