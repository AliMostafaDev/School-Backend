using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.API.Models;
using System.Security.Principal;

namespace School.API.Data.Config
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(x => x.ClassName)
                .HasColumnType("Varchar")
                .HasMaxLength(20);
        }
    }
}
