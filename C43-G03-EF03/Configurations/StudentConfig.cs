using C43_G03_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C43_G03_EF03.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.FName)
                .HasMaxLength(50);

            builder.Property(e => e.LName)
                .HasMaxLength(50);
        }
    }
}