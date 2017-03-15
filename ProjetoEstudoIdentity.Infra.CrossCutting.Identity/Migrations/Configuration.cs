using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Context;
using System.Data.Entity.Migrations;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
        }
    }
}