using Core.DataAccess;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class ProjectDal(NowadaysDbContext context) : Repository<Project, NowadaysDbContext>(context), IProjectDal
    {
    }
}
