using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshtokenRepository : EfRepositoryBase<RefreshTokenDto, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshtokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
