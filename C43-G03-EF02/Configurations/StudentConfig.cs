using C43_G03_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C43_G03_EF02.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
