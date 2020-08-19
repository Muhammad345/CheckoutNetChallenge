using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Constants
{
    public static class CheckOutAppConstants
    {
        public static class ValidationMessage
        {
            public const string CardNumerLength = "Card Number must be Valid length.16 digit ";
            public const string CardMonth = "Must be Valid Month";
            public const string CardYear = "Must be Valid Year";
            public const string Cvv = "Must be vaid not greater then 3 number.";
            public const string CardHolderName = "Name Must be valid.";
        }
        public static class PaymentStatus
        {
            public const string Accepted = "Accepted";
            public const string Declined = "Declined";
        }
            
    }
}
