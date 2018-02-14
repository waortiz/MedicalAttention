namespace MedicalAttention.Repositories
{
    using MedicalAttention.Repositories.Model;
    using System.Data.Entity;

    /// <summary>
    /// Information of the database context.
    /// </summary>
    public class MedicalAttentionContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<State> States { get; set; }

        public MedicalAttentionContext() : base("name=MedicalAttentionContext")
        {
            Database.SetInitializer(new MedicalAttentionInitializer());
        }
    }
}
