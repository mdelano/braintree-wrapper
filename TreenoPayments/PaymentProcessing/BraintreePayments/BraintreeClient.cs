using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreenoPayments.PaymentProcessing.BraintreePayments
{
    public class BraintreeClient
    {
        public static BraintreeGateway SANDBOX_GATEWAY = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            PublicKey = "yhj9tygggykt8nx4",
            PrivateKey = "0f89ef6350ee321d40a56f00bbbc6dbd",
            MerchantId = "6pzgr3n7h887nssm"
        };
    }
}
