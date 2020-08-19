using CheckOutCore.Client;
using CheckOutCore.Domain;
using CheckOutRepository.Model;
using Core.IServices;
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
        public async Task<CheckOutHttpClientResponse> ChargeCard(CardDetail cardDetail)
        {
            var endPoint = "API/CardPaymentProcess";
            return  await _acquiringBankHttpClient.Post<CardDetail, CheckOutHttpClientResponse>(endPoint, cardDetail);
           
        }
    }
}
