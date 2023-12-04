using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Infrastructure.Configurations;

public class MovieDirectorConfiguration : IEntityTypeConfiguration<MovieDirector>
{
    public void Configure(EntityTypeBuilder<MovieDirector> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new PersonId(x));
        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new PersonName(x))
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new PersonName(x))
            .IsRequired();

        builder.HasData(new List<MovieDirector>
        {
            new (Guid.Parse("64c3c179-2924-48c9-a521-d4e936588fcc"), "Ridley", "Scott"),
            new (Guid.Parse("bfbd87c3-4fdc-477d-8d25-fb43c7e0f3cc"), "Quentin", "Tarantino"),
            new (Guid.Parse("d8fe0aab-36c2-4a8b-ae50-9230bc84216e"), "Martin", "Scorsese"),
            new (Guid.Parse("8c0c48df-4010-4819-90d5-5a9c676052c2"), "Martin", "McDonagh"),
            new (Guid.Parse("6a86a3d1-8778-4b23-b774-12a32a9c09d3"), "James", "Cameron"),
            new (Guid.Parse("e1d8672d-2472-4582-9b7d-0f61d6bb841a"), "Alejandro G.", "Inarritu"),
            new (Guid.Parse("e1be7b21-c0c9-4559-9276-7bb290796c4c"), "Damien", "Chazelle"),
            new (Guid.Parse("7d6d7422-343f-4a01-83e4-7f994c89751f"), "Francis", "Ford Coppola"),
        });
    }
}