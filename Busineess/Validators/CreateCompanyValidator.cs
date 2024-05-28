using Busineess.DTOs.Company;
using FluentValidation;

namespace Busineess.Validators
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.");
            RuleFor(c => c.Name)
                .MinimumLength(3).WithMessage("Şirket adı en az 3 karakter olmalıdır.");
            RuleFor(c => c.Name)
                .MaximumLength(50).WithMessage("Şirket adı en fazla 50 karakter olmalıdır.");
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(c => c.Address)
                .MinimumLength(10).WithMessage("Adres en az 10 karakter olmalıdır.");
            RuleFor(c => c.Address)
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olmalıdır.");
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.");
            RuleFor(c => c.Phone)
                .Matches(@"^(\d{10})$").WithMessage("Telefon numarası 10 haneli olmalıdır.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email boş olamaz.");
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        }
    }
}
