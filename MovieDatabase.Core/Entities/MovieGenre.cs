namespace MovieDatabase.Core.Entities;

public sealed class MovieGenre
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }

    public MovieGenre(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public static MovieGenre Action => new(Guid.Parse("3917d5c5-bb35-4598-8a98-54b636a19732"), nameof(Action));
    public static MovieGenre Crime => new(Guid.Parse("346f62f3-0062-4ff6-90ce-812f3c68b1e0"), nameof(Crime));
    public static MovieGenre Comedy => new(Guid.Parse("8d9ce5ca-67ac-4e07-bc24-035f0242d761"), nameof(Comedy));
    public static MovieGenre Drama => new(Guid.Parse("4fd4a594-620b-44b6-9008-61d6ae25a105"), nameof(Drama));
    public static MovieGenre Horror => new(Guid.Parse("7f7d8135-8483-4987-a91e-318fb3ca7d9e"), nameof(Horror));
    public static MovieGenre SciFi => new(Guid.Parse("70f2c277-a4c8-4423-a6ff-da51b40df21c"), nameof(SciFi));
    public static MovieGenre Fantasy => new(Guid.Parse("3322e9e3-b497-4b29-b49f-32e3937d2e1b"), nameof(Fantasy));
    public static MovieGenre War => new(Guid.Parse("3042e90f-edfe-4bde-843a-1f8562c82acf"), nameof(War));

    public static IEnumerable<MovieGenre> GetAllGenres()
    {
        yield return Action;
        yield return Crime;
        yield return Comedy;
        yield return Drama;
        yield return Horror;
        yield return SciFi;
        yield return Fantasy;
        yield return War;
    }
}