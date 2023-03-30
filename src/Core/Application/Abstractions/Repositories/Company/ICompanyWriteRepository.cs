using Application.DTOs.Company;
using Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories.Company
{
    public interface ICompanyWriteRepository:IEfWriteRepository<CompanyDoc>
    {
      
    }
}
