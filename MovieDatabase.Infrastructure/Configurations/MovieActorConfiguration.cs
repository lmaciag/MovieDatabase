using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Infrastructure.Configurations;

public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
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

        builder.HasData(new List<MovieActor>
        {
            new (Guid.Parse("146effe4-49d6-4ffc-948c-c566cfc64843"), "Bruce", "Willis"),
            new (Guid.Parse("adea0690-9f31-4d69-a2bb-a2183cf156e5"), "John", "Travolta"),
            new (Guid.Parse("f2c16575-06b5-405c-add4-25256d5efa95"), "Samuel L.", "Jackson"),
            new (Guid.Parse("947a99ac-592e-4a21-bbff-f12ff61826f6"), "Uma", "Thurman"),
            new (Guid.Parse("38bfd380-187c-4448-82a4-f208ef032b6e"), "Colin", "Farrell"),
            new (Guid.Parse("7dc4bf77-61bc-4579-abf1-4d064dce0ed3"), "Brendan", "Gleeson"),
            new (Guid.Parse("301011d6-1c02-4d2d-9940-6a0fa45c6f76"), "Leonardo", "DiCaprio"),
            new (Guid.Parse("f923c19b-50e4-444a-8dfc-bc490000d1c1"), "Robert", "De Niro"),
            new (Guid.Parse("88dcbc82-cbc4-4eb9-9739-9a7b74902fd7"), "Jesse", "Plemons"),
            new (Guid.Parse("45dd20db-823b-4e96-bba4-d7fc36783d18"), "Michael", "Keaton"),
            new (Guid.Parse("4b124488-270d-4a06-9003-dc9a1787b55d"), "Zach", "Galifianakis"),
            new (Guid.Parse("1a55dcfb-a1d3-45ff-ae58-e621e2a424ad"), "Edward", "Norton"),
            new (Guid.Parse("d33fed2e-7e98-4414-8826-ead5f473dd7a"), "Emma", "Stone"),
            new (Guid.Parse("0a3abde0-f162-4db2-a7e7-5643f1d58b4d"), "Ryan", "Gosling"),
            new (Guid.Parse("3c7f7291-af01-4187-bd01-3571fc9886df"), "Harrison", "Ford"),
            new (Guid.Parse("23935d7f-ec38-40d9-9128-2b1bc976205f"), "Rutger", "Hauer"),
            new (Guid.Parse("f6a21b06-4d74-46f6-8bd5-54a16fdf074b"), "Sean", "Young"),
            new (Guid.Parse("ff25b94c-dd14-4dc4-8e93-9c8636ce92db"), "Kate", "Winslet"),
            new (Guid.Parse("daed329f-1278-4d62-86b1-28e515c7c476"), "Brad", "Pitt"),
            new (Guid.Parse("0da5afee-318b-41ac-ba1e-f8cfff666dd9"), "Bradley", "Cooper"),
        });
    }
}