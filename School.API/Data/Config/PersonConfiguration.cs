using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.API.Models;

namespace School.API.Data.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(x => x.FirstName)
                .HasColumnType("Varchar")
                .HasMaxLength(20);

            builder.Property(x => x.SecondName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .HasColumnType("Varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);



            builder.UseTpcMappingStrategy();
            

        }
    }
}
