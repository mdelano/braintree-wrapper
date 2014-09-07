using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// This defines the contract for handling payment related transactions at a payment provider
    /// </summary>
    /// <typeparam name="PaymentMethod">The type of the payment method required by a payment provider. 
    /// For example, ror sale transactions, Braintree requires a single string of the Nonce created on 
    /// the client. However, some payment providers may require the full credit card details for processing 
    /// payment transactions.</typeparam>
    /// <typeparam name="Response">The type that would be returned from a payment provider</typeparam>
    public interface ITransactionService<PaymentMethod, Response>
    {
        /// <summary>
        /// A sale should authoriza and settle a transaction at the payment provider. 
        /// 
        /// Some providers will offer the ability to do this synchronously while others will 
        /// offer the ability to request settlement which will be process at a later time
        /// </summary>
        /// <param name="paymentMethod">This can be a payment token or credit card information. 
        /// This should be an object that the payment provider will accept as to authorize a 
        /// transaction</param>
        /// <param name="amount">The amount of the sale</param>
        /// <returns></returns>
        Response Sale(PaymentMethod paymentMethod, Decimal amount);

        /// <summary>
        /// An authorization holds funds in a payors credit card account but does not move them (settlement) to the payees account.
        /// </summary>
        /// <param name="paymentMethod">This can be a payment token or credit card information. 
        /// This should be an object that the payment provider will accept as to authorize a 
        /// transaction</param>
        /// <param name="amount">The amount of the sale</param>
        /// <returns></returns>
        Response Authorize(PaymentMethod paymentMethod, Decimal amount);

        /// <summary>
        /// Rretrieve the authorized funds from the payors account and move them to the payees account
        /// </summary>
        /// <param name="authorizationId">The idetifier of the authorization transaction</param>
        /// <param name="amount"></param>
        /// <returns></returns>
        Response Settle(String authorizationId, Decimal amount);

        /// <summary>
        /// Remove a previously authrorizaed transaction to rpevent settlement
        /// </summary>
        /// <param name="authorizationId">The idetifier of the authorization transaction</param>
        /// <returns></returns>
        Response Void(String authorizationId);
    }
}
