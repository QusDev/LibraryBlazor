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
                .WithMany()
                .HasForeignKey(i => i.ReaderId);

            builder
                .HasOne(i => i.Book)
                .WithMany()
                .HasForeignKey(i => i.BookId);
        }
    }
}
