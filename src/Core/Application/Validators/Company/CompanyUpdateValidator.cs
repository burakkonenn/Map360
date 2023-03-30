using Application.DTOs.Company;
using FluentValidation;


namespace Application.Validators.Company
{
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(n => n.CompanyName)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen şirket adını boş bırakmayınız");

            RuleFor(n => n.CompanyAddress)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen şirketin adres alanını boş bırakmayınız");

            RuleFor(n => n.CompanyPhone)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen şirketin iletişim numarasını boş bırakmayınız");

            RuleFor(n => n.CompanyTaxNumber)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen şirketin vergi numarası alanını boş bırakmayınız");


        }
    }
}
