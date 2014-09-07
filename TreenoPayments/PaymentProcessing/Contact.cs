using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public class Contact
    {
        public String ContactId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }

        protected Contact(){}

        public Contact(String firstName, String lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Contact(String firstName, String lastName, String email) : this(firstName, lastName)
        {
            this.Email = email;
        }

        public Contact(String firstName, String lastName, String email, String phone) : this(firstName, lastName, email)
        {
            this.Phone = phone;
        }

        public Contact(String firstName, String lastName, String email, String phone, String company, String fax) : this(firstName, lastName, email, phone)
        {
            this.Company = company;
            this.Fax = fax;
        }
    }
}
