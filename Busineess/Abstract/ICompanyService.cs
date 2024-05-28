using Busineess.DTOs.Company;
using Business.Wrappers;

namespace Busineess.Abstract
{
    public interface ICompanyService
    {
        Task<IResult> AddAsync(CreateCompanyDto companyDto);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(UpdateCompanyDto companyDto);
    }
}
