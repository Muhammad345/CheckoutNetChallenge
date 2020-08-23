using CheckOutCore.Client;
using CheckOutCore.Domain;
using CheckOutRepository.Model;
using Core.IServices;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servcies
{
    public class CardApiService : ICardApiService
    {
        private readonly IHttpClient _acquiringBankHttpClient;

        public CardApiService(IHttpClient acquiringBankHttpClient)
        {
            _acquiringBankHttpClient = acquiringBankHttpClient;
        }
        public async Task<CheckOutHttpClientResponse> ChargeCard(CardPaymentDetail cardPaymentDetail)
        {
            var endPoint = "API/CardPaymentProcess";
            return  await _acquiringBankHttpClient.Post<CardPaymentDetail, CheckOutHttpClientResponse>(endPoint, cardPaymentDetail);
           
        }
    }
}
