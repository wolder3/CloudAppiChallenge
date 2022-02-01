using ChallengeBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBackend.Insfrastucture.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Id).IsUnique();

            builder.Property(e => e.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Zip)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasOne(d => d.User)
                .WithOne(p => p.Address)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_address_user");
        }
    }
}
