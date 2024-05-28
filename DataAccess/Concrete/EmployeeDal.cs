using Core.DataAccess;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EmployeeDal(NowadaysDbContext context) : Repository<Employee, NowadaysDbContext>(context), IEmployeeDal
    {
    }
}
