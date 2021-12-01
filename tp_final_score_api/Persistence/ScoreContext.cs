
using Microsoft.EntityFrameworkCore;
using tp_final_score_api.Persistence.Models;

namespace tp_final_score_api.Persistence
{
    public class ScoreContext : DbContext
    {
       
        public ScoreContext(DbContextOptions options ) : base( options )
        {
           
        }
        public DbSet<Score> Scores { get; set; }


     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Score>(item =>
            {
                item.ToTable("score");
                item.HasKey(score => score.Id);
            });

        }
    }
}
