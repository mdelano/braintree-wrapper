using BraintreePayments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

namespace TreenoPayments.PaymentProcessing.BraintreePayments
{

    class BraintreePaymentProvider : IPaymentProvider
    {
        public ICustomerService<Customer> CustomerService;
        public ITransactionService<String, BraintreeResponse<Braintree.Transaction>> TransactionService;
        public IPaymentMethodService<String, String> PaymentMethodService;

        public BraintreePaymentProvider()
        {
            this.CustomerService = new BraintreeCustomerService();
            this.TransactionService = new BraintreeTransactionService();
            this.PaymentMethodService = new BraintreePaymentMethodService();
        }
    }
}
