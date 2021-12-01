using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tp_final_score_api.Persistence;
using tp_final_score_api.Persistence.Models;
using tp_final_score_api.Repositories.Interfaces;

namespace tp_final_score_api.Repositories
{
    public class ScoreRepository : IScoreRepository 
    {
        private readonly ScoreContext _context;
        public ScoreRepository(ScoreContext context)
        {
            _context = context;
        }

        public async Task<Score> Create(Score objet)
        {
            objet.Date = DateTime.Now;
            _context.Set<Score>().Add(objet);
            await _context.SaveChangesAsync();
            return objet;
           
        }

        public async virtual Task<Score> Delete(string userName, int id)
        {
            Score toDelete = await _context.Scores.Where(score => score.UserName == userName && score.Id == id).FirstOrDefaultAsync();

            _context.Scores.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<Score> Get(string userName, int id)
        {
            return await _context.Set<Score>().Where(score => score.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Score>> GetAll(string username)
        {
            return  await _context.Set<Score>().Where(score => score.UserName == username).ToListAsync();
        }

       
    }
}
