using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Infrastructure.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new MovieId(x));
        builder.Property(x => x.Title)
            .HasConversion(x => x.Value, x => new MovieTitle(x))
            .IsRequired();
        builder.Property(x => x.Genre)
            .HasConversion(x => x.Value, x => new MovieGenre(x))
            .IsRequired();
        builder.Property(x => x.ReleaseDate)
            .HasConversion(x => x.Value.ToDateTime(TimeOnly.MinValue), x => new MovieReleaseDate(DateOnly.FromDateTime(x)))
            .HasColumnType("date")
            .IsRequired();
        builder.Property(x => x.BoxOffice)
            .HasConversion(x => x.Value, x => new MovieBoxOffice(x))
            .IsRequired();
        builder.Property(x => x.Length)
            .HasConversion(x => x.Value, x => new MovieLength(x))
            .IsRequired();
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        builder.HasOne(x => x.Director)
            .WithMany()
            .IsRequired();
        builder.HasMany(x => x.Actors)
            .WithMany();
    }
}