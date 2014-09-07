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
    /// This service is responsible for managing customers at Braintree Payments
    /// </summary>
    class BraintreeCustomerService : ICustomerService<TreenoPayments.PaymentProcessing.Customer>
    {
        /// <summary>
        /// Create a new customer a Braintree Payments
        /// 
        /// A customer needs a minimum of a name (first name and last name).
        /// Optionaly, the customer can have an address. If an address is present 
        /// then a new address will be created at Braintree for the customer
        /// 
        /// </summary>
        /// <param name="Customer">The customer defines the personal and address information for a payor</param>
        public void Create(TreenoPayments.PaymentProcessing.Customer Customer)
        {
            // First we attempt to create the customer using only the personal information
            if (Customer.Contact == null) // We need at least this much to create a customer in Braintree
            {
                throw new PaymentProviderServiceException("The Customer.Contact cannot be null");
            }

            // We build a Braintree request mapped from our own customer
            CustomerRequest customerRequest = mapCustomerRequest(Customer);

            // Attempt to create the new customer at Braintree
            Result<Braintree.Customer> result = BraintreeClient.SANDBOX_GATEWAY.Customer.Create(customerRequest);
            BraintreeResponse<Braintree.Customer> response = new BraintreeResponse<Braintree.Customer>(result);

            // Braintree sends back a validation object that describes if the request was successful or not
            if (!response.IsSuccess())
            {
                throw new PaymentProviderServiceException(response.getResponseMessage(), response.getProviderResponse());
            }

            Customer.CustomerId = response.getProviderResponse().Target.Id;

            // If we have an address on our customer we'll attempt to create an address associate 
            // with the new customer at Braintree
            if (Customer.Address != null)
            {
                // Again, we map a Braintree request from our own customer
                AddressRequest addressRequest = mapAddressRequest(Customer);

                // Attempt to create the new address at Braintree
                Result<Braintree.Address> addressResult = BraintreeClient.SANDBOX_GATEWAY.Address.Create(Customer.CustomerId, addressRequest);
                BraintreeResponse<Braintree.Address> addressResponse = new BraintreeResponse<Braintree.Address>(addressResult);

                if (!addressResponse.IsSuccess())
                {
                    throw new PaymentProviderServiceException(response.getResponseMessage(), response.getProviderResponse());
                }
            }
        }

        /// <summary>
        /// Reads an existing customer from Braintree
        /// </summary>
        /// <param name="CustomerId">The cuteroms identifier in Braintree</param>
        /// <returns></returns>
        public TreenoPayments.PaymentProcessing.Customer Read(String CustomerId)
        {
            Braintree.Customer result = BraintreeClient.SANDBOX_GATEWAY.Customer.Find(CustomerId);

            TreenoPayments.PaymentProcessing.Customer customer = new TreenoPayments.PaymentProcessing.Customer();
            if (result != null)
            {
                // Create our own customer from the Braintree customer
                customer = mapCustomer(result);
            }

            return customer;
        }

        /// <summary>
        /// Modifies an existing customer
        /// </summary>
        /// <param name="customerId">The Id of the cutomer to receive the changes</param>
        /// <param name="Customer">The changes to make to the customer</param>
        public void Update(string customerId, TreenoPayments.PaymentProcessing.Customer Customer)
        {
            CustomerRequest customerRequest = mapCustomerRequest(Customer);
            Result<Braintree.Customer> result = BraintreeClient.SANDBOX_GATEWAY.Customer.Update(customerId, customerRequest);
            BraintreeResponse<Braintree.Customer> response = new BraintreeResponse<Braintree.Customer>(result); // Wrap the response in something that everyone understands

            if (!response.IsSuccess())
            {
                throw new PaymentProviderServiceException(response.getResponseMessage(), response.getProviderResponse());
            }
        }

        /// <summary>
        /// Remove a customer from Braintree
        /// </summary>
        /// <param name="customerId">The Id of the customer to remove</param>
        public void Delete(string customerId)
        {
            BraintreeClient.SANDBOX_GATEWAY.Customer.Delete(customerId);
        }

       

        /// <summary>
        /// Maps a Braintree customer to our own customer
        /// </summary>
        /// <param name="inCustomer">The customer to map from</param>
        /// <returns></returns>
        private TreenoPayments.PaymentProcessing.Customer mapCustomer(Braintree.Customer inCustomer) {
            TreenoPayments.PaymentProcessing.Customer outCustomer = new TreenoPayments.PaymentProcessing.Customer() {
                CustomerId = inCustomer.Id,
                Contact = new TreenoPayments.PaymentProcessing.Contact(inCustomer.FirstName, inCustomer.LastName),                
            };

            if(inCustomer.Addresses != null) {
                Braintree.Address address = inCustomer.Addresses.FirstOrDefault(); // We're only dealing with a single address for the customer since we're not shipping anything
                outCustomer.Address = new TreenoPayments.PaymentProcessing.Address(
                    address.StreetAddress, address.ExtendedAddress, address.Locality, address.Region, address.PostalCode, address.CountryCodeAlpha2
                );
            }

            return outCustomer;
        }

        /// <summary>
        /// Maps our customer to a Braintree customer request
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        private CustomerRequest mapCustomerRequest(TreenoPayments.PaymentProcessing.Customer Customer)
        {
            if (Customer.Contact == null) // We need at least this much to create a customer in Braintree
            {
                throw new PaymentProviderServiceException("The Customer.Contact cannot be null");
            }

            CustomerRequest customerRequest = new CustomerRequest();
            customerRequest.FirstName = Customer.Contact.FirstName;
            customerRequest.LastName = Customer.Contact.LastName;

            return customerRequest;
        }

        /// <summary>
        /// Maps our cutomers address to a Braintree address request
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        private AddressRequest mapAddressRequest(TreenoPayments.PaymentProcessing.Customer Customer)
        {
            AddressRequest addressRequest = new AddressRequest();

            addressRequest.FirstName = Customer.Contact.FirstName;
            addressRequest.LastName = Customer.Contact.LastName;
            addressRequest.StreetAddress = Customer.Address.StreetAddress;
            addressRequest.ExtendedAddress = Customer.Address.ExtendedAddress;
            addressRequest.Locality = Customer.Address.Locality;
            addressRequest.Region = Customer.Address.Region;
            addressRequest.PostalCode = Customer.Address.PostalCode;
            addressRequest.CountryCodeAlpha2 = Customer.Address.CountryCodeAlpha2;

            return addressRequest;
        }
    }
}
