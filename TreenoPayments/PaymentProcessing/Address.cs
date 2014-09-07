using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing
{
    public class Address
    {
        public String StreetAddress { get; set; }
        public String ExtendedAddress { get; set; }
        public String Locality { get; set; }
        public String Region { get; set; }
        public String PostalCode { get; set; }
        public String CountryCodeAlpha2 { get; set; }

        protected Address(){}

        public Address(String streetAddress, String locality, String region, String postalCode, String countryCodeAlpha2)
        {
            this.StreetAddress = streetAddress;
            this.Locality = locality;
            this.Region = region;
            this.PostalCode = postalCode;
            this.CountryCodeAlpha2 = countryCodeAlpha2;
        }

        public Address(String streetAddress, String extendedAddress, String locality, String region, String postalCode, String countryCodeAlpha2) 
            : this(streetAddress, locality, region, postalCode, countryCodeAlpha2)
        {
            this.ExtendedAddress = extendedAddress;
        }
    }
}
