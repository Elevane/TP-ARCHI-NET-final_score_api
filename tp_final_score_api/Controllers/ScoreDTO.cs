using AutoMapper;
using tp_final_score_api.Persistence.Models;
using tp_final_score_api.Utils.Mapper;

namespace tp_final_score_api.Controllers
{
    public class ScoreDTO : IMapFrom<Score>
    {
        public string UserName { get; set; }
        public int Value { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Score, ScoreDTO>().ReverseMap();
        }
    }
}
