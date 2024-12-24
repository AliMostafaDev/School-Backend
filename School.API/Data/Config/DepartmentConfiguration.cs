using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.API.Models;

namespace School.API.Data.Config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.DepartmentName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);
        }
    }
}
