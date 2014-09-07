using Braintree;
using BraintreePayments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

/**
 * BraintreeCustomerService
 * 
 * Company: Treeno Software
 * Author: Mike Delano
 * 
 **/

namespace TreenoPayments.PaymentProcessing.BraintreePayments
{
    
    /// <summary>
    /// This service is responsible for managing transactions at Braintree Payments
    /// </summary>
    class BraintreeTransactionService : ITransactionService<String, BraintreeResponse<Braintree.Transaction>>
    {

        public BraintreeResponse<Braintree.Transaction> Sale(string nonce, decimal amount)
        {
            TransactionRequest transactionRequest = new TransactionRequest();

            transactionRequest.Amount = amount;
            transactionRequest.PaymentMethodNonce = nonce;
            // Tell Braintree that we'd like to settle the transaction immediately
            transactionRequest.Options = new TransactionOptionsRequest { SubmitForSettlement = true, StoreInVaultOnSuccess = true, AddBillingAddressToPaymentMethod = true };

            Result<Braintree.Transaction> result = BraintreeClient.SANDBOX_GATEWAY.Transaction.Sale(transactionRequest);
            BraintreeResponse<Braintree.Transaction> salesTransactionResponse = new BraintreeResponse<Braintree.Transaction>(result);

            return salesTransactionResponse;     
        }

        public BraintreeResponse<Braintree.Transaction> Authorize(string nonce, decimal amount)
        {
            throw new NotImplementedException();
        }

        public BraintreeResponse<Braintree.Transaction> Settle(string authorizationId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public BraintreeResponse<Braintree.Transaction> Void(string authorizationId)
        {
            throw new NotImplementedException();
        }
    } 
}
