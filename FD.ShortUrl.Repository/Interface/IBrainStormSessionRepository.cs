using FD.ShortUrl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FD.ShortUrl.Repository
{
    public interface IBrainstormSessionRepository
    {
        Task<BrainstormSession> GetByIdAsync(int id);
        Task<List<BrainstormSession>> ListAsync();
        Task AddAsync(BrainstormSession session);
        Task UpdateAsync(BrainstormSession session);
    }
}
