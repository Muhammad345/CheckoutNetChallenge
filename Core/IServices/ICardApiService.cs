using CheckOutCore.Domain;
using CheckOutRepository.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICardApiService
    {
        Task<CheckOutHttpClientResponse> ChargeCard(CardPaymentDetail cardPaymentDetail);
    }
}
