using AutoMapper;
using Busineess.Abstract;
using Busineess.DTOs.Company;
using Business.Wrappers;
using Core.Wrappers;
using DataAccess.UoW;
using Entities;
using Entities.Enums;

namespace Busineess.Concrete
{
    public class CompanyService(IUnitOfWork unitOfWork, IMapper mapper) : ICompanyService
    {
        public async Task<IResult> AddAsync(CreateCompanyDto companyDto)
        {
            Company company = mapper.Map<Company>(companyDto);
            OperationResult<Company> result =  await unitOfWork.Companies.AddAsync(company);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Company>.CreateResult(result, EntityType.Company, ActionType.Add);
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            var result = await unitOfWork.Companies.DeleteByIdAsync(id);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Company>.CreateResult(result, EntityType.Company, ActionType.Delete);
        }

        public async Task<IResult> UpdateAsync(UpdateCompanyDto companyDto)
        {
            Company company = mapper.Map<Company>(companyDto);
            OperationResult<Company> result = await unitOfWork.Companies.UpdateAsync(company);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Company>.CreateResult(result, EntityType.Company, ActionType.Update);
        }
    }
}
