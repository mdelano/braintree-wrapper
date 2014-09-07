using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreenoPayments.PaymentProcessing;

namespace TreenoPayments.PaymentProcessing
{
    /// <summary>
    /// This class handles any customer management at the payment provider
    /// </summary>
    /// <typeparam name="CustomerType"></typeparam>
    public interface ICustomerService<CustomerType>
        where CustomerType : Customer
    {
        /// <summary>
        /// Creates a new customer at the payment provider. 
        /// 
        /// Customers are used to maintain address and payment method data for reuse on 
        /// subsequent payment transactions
        /// </summary>
        /// <param name="customer"></param>
        void Create(CustomerType customer);

        /// <summary>
        /// Gets an existing customer from the payment provider
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        CustomerType Read(String customerId);

        /// <summary>
        /// Modifies an existing customer at the payment provider
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="Customer"></param>
        void Update(String customerId, CustomerType Customer);

        /// <summary>
        /// Removes an existing customer from the payment provider
        /// </summary>
        /// <param name="customerId"></param>
        void Delete(String customerId);
    }
}
