using ProjetoEstudoIdentity.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstudoIdentity.Infra.Data.EntityConfig
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .HasMaxLength(256);

            Property(u => u.PhoneNumberConfirmed)
                .IsRequired();

            Property(u => u.TwoFactorEnabled)
                .IsRequired();

            Property(u => u.AccessFailedCount)
                .IsRequired();

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("Users");
        }
    }
}