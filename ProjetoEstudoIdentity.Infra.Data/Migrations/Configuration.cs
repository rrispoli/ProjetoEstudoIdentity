using ProjetoEstudoIdentity.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace ProjetoEstudoIdentity.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoEstudoEntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetoEstudoEntityContext context)
        {
        }
    }
}