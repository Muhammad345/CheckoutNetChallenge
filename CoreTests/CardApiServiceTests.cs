using CheckOutCore.Client;
using CheckOutCore.Domain;
using CheckOutPaymentPageApi.Models;
using CheckOutRepository.Model;
using Core.IServices;
using Core.Servcies;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using static Repository.Constants.CheckOutAppConstants;

namespace CoreTests
{
    public class CardApiServiceTests
    {
        private string _url;
        private string _cardNumer;
        private int _accountId;
        private int _merchantId;
        private Guid _externalRefId;
        private CardPaymentResponse _cardPaymentResponse;
        private CardDetail _cardDetail;
        private CheckOutHttpClientResponse _checkOutHttpClientResponse;
        private ICardApiService _cardApiService;
        private readonly Mock<IHttpClient> _mockcheckoutHttpClient;



        [SetUp]
        public void Setup()
        {
            _externalRefId = Guid.NewGuid();
            _accountId = 1;
            _merchantId = 1;
            _cardNumer = "12323232";
            _cardPaymentResponse = new CardPaymentResponse
            {
                AuthCode = "AuthCode01",
                ExternalRefId = _externalRefId,
                Status = "Accepted"
            };

            _cardDetail = new CardDetail
            { 
                AccountId = _accountId,
                MerchantId = _merchantId,
                CardNumber = _cardNumer,
                CardExpiry_Month = "02",
                CardExpiry_Year ="2020",
                CVV = "123"

              
            };
            _checkOutHttpClientResponse = new CheckOutHttpClientResponse();
            _checkOutHttpClientResponse.Data = JsonConvert.SerializeObject(_cardPaymentResponse);
            _checkOutHttpClientResponse.IsSuccessFull = true;
            _checkOutHttpClientResponse.StatusCode = HttpStatusCode.OK ;
            _url = "anyURL";
            //_mockcheckoutHttpClient = new Mock<IHttpClient>().Object;
            _mockcheckoutHttpClient.Setup(x => x.Post<CardDetail, CheckOutHttpClientResponse>(_url, _cardDetail)).ReturnsAsync(_checkOutHttpClientResponse);
            _cardApiService = new CardApiService(_mockcheckoutHttpClient.Object);
        }

        [Test]
        public void MockBankApi_ReponseAccepeted()
        {
            var cardApiResult = _cardApiService.ChargeCard(_cardDetail);
            var cardApiResponse = cardApiResult.Result;
            var cardPaymentResponse = JsonConvert.DeserializeObject<CardPaymentResponse>(cardApiResponse.Data);

            Assert.AreEqual(cardPaymentResponse.Status, PaymentStatus.Accepted);
        }

        [Test]
        public void MockBankApi_ResponseDeclined()
        {
            _cardPaymentResponse.Status = PaymentStatus.Declined;

            var cardApiResult = _cardApiService.ChargeCard(_cardDetail);
            var cardApiResponse = cardApiResult.Result;
            var cardPaymentResponse = JsonConvert.DeserializeObject<CardPaymentResponse>(cardApiResponse.Data);

            Assert.AreEqual(cardPaymentResponse.Status, PaymentStatus.Declined);
        }
    }
}