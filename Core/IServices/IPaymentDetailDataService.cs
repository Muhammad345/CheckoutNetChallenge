using CheckOutRepository.Model;
using Core.Response;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IServices
{
    public interface IPaymentDetailDataService
    {
        ServiceResponse Save(CardPaymentDetail cardPaymentDetail, string status);

        IEnumerable<CardPaymentDetail> Get(int merchantId, int accountId);

        CardPaymentDetail Get(Guid ExternalRefId);
    }
}
