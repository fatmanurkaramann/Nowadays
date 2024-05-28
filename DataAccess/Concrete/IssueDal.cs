using Core.DataAccess;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class IssueDal(NowadaysDbContext context) : Repository<Issue, NowadaysDbContext>(context), IIssueDal
    {
    }
}
