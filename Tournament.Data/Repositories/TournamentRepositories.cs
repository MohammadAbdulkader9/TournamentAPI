using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class TournamentRepository : RepositoryBase<TournamentDetails>, ITournamentRepository
    {
        //private readonly TournamentContext _context;

        public TournamentRepository(TournamentContext context) : base(context) { }

        public async Task<IEnumerable<TournamentDetails>> GetAllAsync(bool includeGames = false, bool trackChanges = false)
        {
            return includeGames ?  await FindAll(trackChanges).Include(t => t.Games).ToListAsync() :
                                   await FindAll(trackChanges).ToListAsync();
        }

        public async Task<TournamentDetails?> GetAsync(int id, bool trackChanges = false)
        {
            return await FindByCondition(t => t.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        }
       
        public async Task<bool> AnyAsync(int id)
        {
            return await FindAll().AnyAsync();
        }

        
        //public void Add(TournamentDetails tournament)
        //{
        //    _context.TournamentDetails.Add(tournament);
        //}

        //public void Update(TournamentDetails tournament)
        //{
        //    _context.TournamentDetails.Update(tournament);
        //}

        //public void Remove(TournamentDetails tournament)
        //{
        //    _context.TournamentDetails.Remove(tournament);
        //}
    }
}
