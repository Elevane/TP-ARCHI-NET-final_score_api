using System.Threading.Tasks;
using tp_final_score_api.Persistence.Models;

namespace tp_final_score_api.Repositories.Interfaces
{
    public interface IScoreRepository
    {
        Task<Score> Get(string userName, int id);
        Task<List<Score>> GetAll(string userName);
        Task<Score> Create(Score objet);

        Task<Score> Delete(string userName, int id);

    }
}
