using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;


namespace FD.ShortUrl.Repository
{
    public class EFStormSessionRepository : IBrainstormSessionRepository
    {
        private readonly BrainStormDb _dbContext;

        public EFStormSessionRepository(BrainStormDb dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<BrainstormSession> GetByIdAsync(int id)
        {
#pragma warning disable CS8619 // 值中的引用类型的为 Null 性与目标类型不匹配。
            return _dbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8619 // 值中的引用类型的为 Null 性与目标类型不匹配。
        }

        public Task<List<BrainstormSession>> ListAsync()
        {
            return _dbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .OrderByDescending(s => s.DateCreated)
                .ToListAsync();
        }

        public Task AddAsync(BrainstormSession session)
        {
            _dbContext.BrainstormSessions.Add(session);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(BrainstormSession session)
        {
            _dbContext.Entry(session).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
