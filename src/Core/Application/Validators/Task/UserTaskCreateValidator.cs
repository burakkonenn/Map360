using Application.DTOs.Company;
using Application.DTOs.CompanyTasks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.CompanyTasks
{
    public class UserTaskCreateValidator : AbstractValidator<TaskCreateDto>
    {
        public UserTaskCreateValidator()
        {
            RuleFor(n => n.Name)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen şirket adını boş bırakmayınız");
        }
    }
}
