using Application.Abstractions.Repositories.Company;
using Application.Abstractions.Services.Company;
using Application.DTOs.Company;
using Application.Wrappers;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Services.Company
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ICompanyWriteRepository _companyWriteRepository;
        public CompanyService(ICompanyReadRepository companyReadRepository, ICompanyWriteRepository companyWriteRepository)
        {
            _companyReadRepository = companyReadRepository;
            _companyWriteRepository = companyWriteRepository;
        }
        public async Task<ServiceResponse> CreateAsync(CompanyCreateDto model)
        {
            var response = new ServiceResponse();
            var company = new CompanyDoc();
            company.Company = new Domain.Entities.Company.Company();
            company.Company.Name = model.CompanyName;
            company.Company.Phone = model.CompanyPhone;
            company.Company.Address = model.CompanyAddress;
            company.Company.TaxNo = model.CompanyTaxNumber;
            company.IsDeleted = false;
            await _companyWriteRepository.AddAsync(company);
            response.IsSuccess = true;
            response.Message = "Kayıt ekleme başarılı";
            return response;
        }
        public async Task<ServiceResponse> Remove(int id)
        {
            ServiceResponse response = new ServiceResponse();
            var company = await _companyReadRepository.GetByIdAsync(id);
            if (company == null)
            {
                response.IsSuccess = false;
                response.Message = "Silinecek kayıt bulunamadı";
                return response;
            }

            await _companyWriteRepository.RemoveAsync(company);
            response.IsSuccess = true;
            return response;
        }
        public async Task<ServiceResponse> UpdateAsync(CompanyUpdateDto model)
        {
            var response = new ServiceResponse();
            var company = await _companyReadRepository.GetByIdAsync(model.CompanyId);
            if (company == null)
            {
                response.IsSuccess = false;
                response.Message = "güncellenecek kayıt bulunamadı";
                return response;
            }
            company.Company.Name = model.CompanyName;
            company.Company.Phone = model.CompanyPhone;
            company.Company.Address = model.CompanyAddress;
            company.Company.TaxNo = model.CompanyTaxNumber;
            company.IsDeleted = false;
            await _companyWriteRepository.UpdateAsync(company);
            response.Message = "Güncelleme başarılı";
            response.IsSuccess = true;
            return response;
        }
        public async Task<ServiceResponse<List<CompanyListDto>>> GetAll()
        {
            var response = new ServiceResponse<List<CompanyListDto>>();
            var query = _companyReadRepository.GetAll().Where(x => x.IsDeleted == false);
            response.Data = await query.Select(x => new CompanyListDto()
            {
                CompanyAddress = x.Company.Address,
                CompanyName = x.Company.Name,
                CompanyPhone = x.Company.Phone,
                CompanyTaxNumber = x.Company.TaxNo,
                CreatedDate = (DateTime)x.CreatedDate,
                UpdatedDate = (DateTime)x.UpdatedDate,
                Id = x.Id
,
            }).ToListAsync();
            return response;
        }
        public async Task<ServiceResponse<CompanyUpdateDto>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<CompanyUpdateDto>();
            var company = await _companyReadRepository.GetByIdAsync(id);
            if (company == null)
            {
                response.Message = "Kayıt Bulunamadı";
                response.IsSuccess = false;
                return response;
            }

            var data = new CompanyUpdateDto();
            data.CompanyTaxNumber = company.Company.TaxNo;
            data.CompanyId = company.Id;
            data.CompanyPhone = company.Company.Phone;
            data.CompanyName = company.Company.Name;
            data.CompanyAddress = company.Company.Address;
            response.IsSuccess = true;
            response.Data = data;
            return response;
        }

        public async Task<ServiceResponse<CompanyDetails>> GetCompanyUsers(int id)
        {
            var response = new ServiceResponse<CompanyDetails>();
            response.Data = await _companyReadRepository.GetCompanyUsers(id);

            if (response.Data == null)
            {
                response.Message = "Kayıt Bulunamadı";
                response.IsSuccess = false;
                return response;
            }

            return response;
        }
    }
}
