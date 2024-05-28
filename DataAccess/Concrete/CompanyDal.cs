using Core.DataAccess;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class CompanyDal(NowadaysDbContext context) : Repository<Company, NowadaysDbContext>(context), ICompanyDal
    {
    }
}
