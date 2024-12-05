using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        void Add(TournamentDetails tournament);
        void Update(TournamentDetails tournament);
        void Remove(TournamentDetails tournament);
        Task<IEnumerable<TournamentDetails>> GetAllAsync(bool includeGames = false, bool trackChanges = false);
        Task<TournamentDetails?> GetAsync(int id, bool trackChanges = false);
        Task<bool> AnyAsync(int id);
    }
}
