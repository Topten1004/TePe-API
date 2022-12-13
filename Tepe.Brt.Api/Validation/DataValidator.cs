using FluentValidation;
using Tepe.Brt.Api.ViewModels;

namespace Tepe.Brt.Api.Validation
{
    public class DataValidator : AbstractValidator<DataVM>
    {
        public DataValidator()
        {
            RuleFor(x => x.email).EmailAddress();
            RuleFor(x => x.phone_number).NotNull().NotEmpty().MaximumLength(20)
                .Must( a => a?.ToLower().Contains("street") == true);
            RuleFor(x => x.comment).NotNull().NotEmpty();
            RuleFor(x => x.teeth_image).NotNull().NotEmpty();
        }
    }
}


