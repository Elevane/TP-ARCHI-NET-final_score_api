using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tp_final_score_api.Persistence.Models;
using tp_final_score_api.Repositories.Interfaces;

namespace tp_final_score_api.Controllers
{

    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ScoreController : Controller
    {

        private readonly IScoreRepository _repo;
        private readonly IMapper _mapper;

        public ScoreController(IScoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>
        /// Permet a l'api gateaway te verifier que le seri
        /// </summary>
        /// <returns></returns>
        [HttpGet("/ping")]
        public async Task<Result> Ping()
        {
            return Result.Ok();
        }

        [HttpGet("/api/v1/[controller]/{userName}")]
        public async Task<Result<List<ScoreDTO>>> GetAll(string userName)
        {
            if (userName == null)
                return Result.BadRequest<List<ScoreDTO>>();
            List<Score> scores = await _repo.GetAll(userName);
            List<ScoreDTO> scoredto = _mapper.Map<List<ScoreDTO>>(scores);
            if (scoredto == null)
                return Result.NotFound<List<ScoreDTO>>();
            return Result.Ok(scoredto);
        }


        [HttpGet("/api/v1/[controller]/{userName}/{scoreId}")]
        public async Task<Result<ScoreDTO>> Get(string userName, int scoreId)
        {
            if (userName == null || scoreId == null)
                return Result.BadRequest<ScoreDTO>();
            Score score = await _repo.Get(userName, scoreId);
            ScoreDTO scoredto = _mapper.Map<ScoreDTO>(score);
            if (scoredto == null)
                return Result.NotFound<ScoreDTO>();
            return Result.Ok(scoredto);
        }


        [HttpPost]
        public async Task<Result<ScoreDTO>> Post([FromBody] ScoreDTO postobjet)
        {
            if (postobjet == null )
                return Result.BadRequest<ScoreDTO>();
            Score toCreate = _mapper.Map<Score>(postobjet);
            Score score = await _repo.Create(toCreate);
            ScoreDTO scoredto = _mapper.Map<ScoreDTO>(score);
            if (scoredto == null)
                return Result.NotFound<ScoreDTO>();
            return Result.Ok(scoredto);
        }


        [HttpDelete("/api/v1/[controller]/{userName}/{scoreId}")]
        public async Task<Result<ScoreDTO>> Delete( int scoreId, string userName)
        {
            if (scoreId == null || userName == null)
                return Result.BadRequest<ScoreDTO>();
            Score score = await _repo.Delete(userName, scoreId);
            ScoreDTO scoredto = _mapper.Map<ScoreDTO>(score);
            if (scoredto == null)
                return Result.NotFound<ScoreDTO>();
            return Result.Ok(scoredto);
        }

    }
}
