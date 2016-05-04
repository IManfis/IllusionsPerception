using System.Data.Entity;

namespace IllusionsPerception.Model
{
    public class IllusionsPerceptionContext : DbContext
    {
        public IllusionsPerceptionContext()
            : base("IllusionsPerception")
        {
        }

        public virtual DbSet<Experiment1Result> Experiment1Result { get; set; }
        public virtual DbSet<Experiment2Result> Experiment2Result { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
