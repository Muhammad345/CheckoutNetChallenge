using AutoMapper;
using CheckOutRepository.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapperProfile
{
    public class CoreAutoMapperProfile : Profile
    {
            public CoreAutoMapperProfile()
            {
                CreateMap<CardPaymentDetail, PaymentDetail>()
                   .ReverseMap();

            CreateMap<CardPaymentDetail, CardDetail>()
                  .ReverseMap();

        }
    }
}
