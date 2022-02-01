using ChallengeBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBackend.Insfrastucture.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Id).IsUnique();

            builder.Property(e => e.Id)
               .IsRequired()
               .UseIdentityColumn();

            builder.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.Email)
              .IsRequired()
              .HasMaxLength(50)
              .IsUnicode(false);

            builder.Property(e => e.BirthDate)
              .IsRequired();

            builder.HasOne(d => d.Address)
              .WithOne(p => p.User)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
