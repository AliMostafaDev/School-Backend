using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.API.Models;

namespace School.API.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
        }
    }
}
