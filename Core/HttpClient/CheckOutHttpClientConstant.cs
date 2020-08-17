namespace CheckOutCore.Constant
{
    public static class CheckOutHttpClientConstant
    {
        public static class Header
        {
            public const string Date = "Date";
            public const string XModNonce = "x-mod-nonce";
            public const string Authorization = "Authorization";
            public const string Accept = "accept";
        }

        public static class EntityName
        {
            public const string Customers = "customers";
            public const string Accounts = "accounts";
            public const string Transactions = "transactions";
            public const string Beneficiaries = "beneficiaries";
            public const string Cards = "cards";
            public const string Credit = "credit";
            public const string Payments = "payments";
            public const string Mandates = "mandates";
            public const string Collectionschedules = "collectionschedules";
        }

        public static class AccountAction
        {
            public const string Block = "block";
            public const string Unblock = "unblock";
            public const string Suspend = "suspend";
            public const string Cancel = "cancel";
        }

        public static class Security
        {
            public const string SignaturekeyId = "Signature keyId";
            public const string Algorithm = "algorithm";
            public const string HmacSha1 = "hmac-sha1";
            public const string Headers = "headers";
            public const string Signature = "signature";
        }

        public static class ContentType
        {
            public const string Application_Json = "application/json";
        }

        public static class Paging
        {
            public const string Page = "page";
            public const string Size = "size";
        }

        public static class QuerString
        {
            public const string SourceAccountId = "sourceAccountId";
            public const string FromCreatedDate = "fromCreatedDate";
        }

    }
}
