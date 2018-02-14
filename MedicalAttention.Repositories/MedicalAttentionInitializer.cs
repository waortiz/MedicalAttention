using MedicalAttention.Repositories.Model;
using MedicalAttention.Entities.Enumerations;
using System.Data.Entity;

namespace MedicalAttention.Repositories
{
    public class MedicalAttentionInitializer : DropCreateDatabaseIfModelChanges<MedicalAttentionContext>
    {
        protected override void Seed(MedicalAttentionContext context)
        {
            context.States.Add(new State() { Id = (int)StateEnum.Assigned, Name = StateEnum.Assigned.ToString() });
            context.States.Add(new State() { Id = (int)StateEnum.Cancelled, Name = StateEnum.Cancelled.ToString() });

            base.Seed(context);
        }
    }
}