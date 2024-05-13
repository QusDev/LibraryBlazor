using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryBlazor.Entity.Configurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .HasOne(i => i.Reader)
                .WithOne()
                .HasForeignKey<Issue>(i => i.ReaderId);

            builder
                .HasOne(i => i.Book)
                .WithOne()
                .HasForeignKey<Issue>(i => i.BookId);
        }
    }
}
