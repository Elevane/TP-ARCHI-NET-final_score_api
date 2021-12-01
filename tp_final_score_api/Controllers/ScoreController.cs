using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tp_final_score_api.Persistence.Models;
using tp_final_score_api.Repositories.Interfaces;

namespace tp_final_score_api.Controllers
{

    [ApiController]
  
    public class ScoreController : Controller
    {

        private readonly IScoreRepository _repo;
        private readonly IMapper _mapper;
        public static string KEY = "qzDQZDIHQZ¨BFIhbyZQAvqumyfvhzùq53zd56qgf5qz4";
        public ScoreController(IScoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>
        /// Permet a l'api gateaway te verifier que le seri
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/{key}/ping")]
        public async Task<Result> Ping(string key)
        {
            if (key != KEY)
                return Result.Unauthorized();
            return Result.Ok();
        }

        [HttpGet("/api/v1/{key}/[controller]/{userName}")]
        public async Task<Result<List<ScoreDTO>>> GetAll(string key, string userName)
        {
            if (key != KEY)
                return Result.Unauthorized<List<ScoreDTO>>();
            if (userName == null)
                return Result.BadRequest<List<ScoreDTO>>();
            List<Score> scores = await _repo.GetAll(userName);
            List<ScoreDTO> scoredto = _mapper.Map<List<ScoreDTO>>(scores);
            if (scoredto == null)
                return Result.NotFound<List<ScoreDTO>>();
            return Result.Ok(scoredto);
        }


        [HttpGet("/api/v1/{key}/[controller]/{userName}/{scoreId}")]
        public async Task<Result<ScoreDTO>> Get(string key, string userName, int scoreId)
        {
            if (key != KEY)
                return Result.Unauthorized<ScoreDTO>();
            if (userName == null || scoreId == null)
                return Result.BadRequest<ScoreDTO>();
            Score score = await _repo.Get(userName, scoreId);
            ScoreDTO scoredto = _mapper.Map<ScoreDTO>(score);
            if (scoredto == null)
                return Result.NotFound<ScoreDTO>();
            return Result.Ok(scoredto);
        }


        [HttpPost("/api/v1/{key}/[controller]")]
        public async Task<Result<ScoreDTO>> Post(string key, [FromBody] ScoreDTO postobjet)
        {
            if (key != KEY)
                return Result.Unauthorized<ScoreDTO>();
            if (postobjet == null )
                return Result.BadRequest<ScoreDTO>();
            Score toCreate = _mapper.Map<Score>(postobjet);
            Score score = await _repo.Create(toCreate);
            ScoreDTO scoredto = _mapper.Map<ScoreDTO>(score);
            if (scoredto == null)
                return Result.NotFound<ScoreDTO>();
            return Result.Ok(scoredto);
        }


        [HttpDelete("/api/v1/{key}/[controller]/{userName}/{scoreId}")]
        public async Task<Result<ScoreDTO>> Delete(string key, int scoreId, string userName)
        {
            if (key != KEY)
                return Result.Unauthorized<ScoreDTO>();
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
