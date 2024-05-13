using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryBlazor.Entity.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity("Books_Genres");

            builder
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity("Books_Authors");
        }
    }
}
