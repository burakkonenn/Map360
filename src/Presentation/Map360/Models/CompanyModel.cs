using Application.DTOs.Company;
using Domain.Entities.Company;

namespace Map360.Models
{
    public class CompanyModel
    {
        public List<CompanyDoc> CompanyDoc { get; set; }
        public CompanyCreateDto CompanyCreate { get; set; }
    }
}
