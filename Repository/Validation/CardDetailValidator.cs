using CheckOutRepository.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Validation
{
    public class CardDetailValidator : AbstractValidator<CardDetail>
    {
		public CardDetailValidator()
		{
			RuleFor(x => x.Name).MinimumLength(3).WithMessage(Constants.CheckOutAppConstants.ValidationMessage.CardHolderName);
		}
	}
}
