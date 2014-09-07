using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing.BraintreePayments;

namespace TreenoPayments.PaymentProcessing
{
    public interface ITransaction<TransactionRequestType, TransactionResponseType>
        where TransactionRequestType : ITransactionRequest
        where TransactionResponseType : ITransactionResponse<Object>
    {
        TransactionResponseType invoke(TransactionRequestType transactionRequest);
    }
}
