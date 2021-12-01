using System.Collections.Generic;

namespace tp_final_score_api.Persistence.Models
{
    public class Score 
    {
        public int Id { get;  } 
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public  string UserName { get; set; }

    }
}
