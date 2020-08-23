using AutoMapper;
using CheckOutRepository.Model;
using Core.IServices;
using Core.Response;
using Repository;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Servcies
{
    public class PaymentDetailDataService : IPaymentDetailDataService
    {
        private readonly IRepository<PaymentDetail> _paymentDetailRepository;
        private readonly IRepository<CardDetail> _cardDetailRepository;
        private readonly IMapper _mapper;

        public PaymentDetailDataService(IRepository<PaymentDetail> paymentDetailRepository, IRepository<CardDetail> cardDetailRepository, IMapper mapper)
        {
            _paymentDetailRepository = paymentDetailRepository;
            _cardDetailRepository = cardDetailRepository;
            _mapper = mapper;
        }
        public IEnumerable<CardPaymentDetail> Get(int merchantId, int accountId)
        {
            // _paymentHistoryRepository.GetAll().Where(x=>x.)

            return null;
        }

        public CardPaymentDetail Get(Guid ExternalRefId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Save(CardPaymentDetail cardPaymentDetail,string status)
        {
            var serviceResponse = new ServiceResponse {};
            try
            {
                var paymentDetail = _mapper.Map<PaymentDetail>(cardPaymentDetail);
                paymentDetail.Status = status;

                var paymentId = _paymentDetailRepository.Insert(paymentDetail);

                var cardDetail = _mapper.Map<CardDetail>(cardPaymentDetail);

                cardDetail.PaymentDetailId = paymentId;

                var cardDetailId = _cardDetailRepository.Insert(cardDetail);

                serviceResponse.IsSuccessFull = true;
                serviceResponse.Result = cardDetail;
            }
            catch (Exception exp)
            {
                serviceResponse.IsSuccessFull = false;
                serviceResponse.Exception = exp;
                serviceResponse.ErrorMessage = "Exception During Saving Data in Payment Data Service";
            }

            return serviceResponse;
        }
    }
}
