using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Infra.Data.EntityConfig;
using System.Data.Entity;

namespace ProjetoEstudoIdentity.Infra.Data.Context
{
    public class ProjetoEstudoEntityContext : DbContext
    {
        public ProjetoEstudoEntityContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
        }
    }
}