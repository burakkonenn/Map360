using Application.DTOs.Company;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Company
{
    public class CompanyCreateValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateValidator()
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
