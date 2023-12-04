using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Core.Entities;

public sealed class Movie
{
    public MovieId Id { get; private set; }
    
    public MovieTitle Title { get; private set; }
    
    public MovieGenre Genre { get; private set; }
    
    public MovieDirector Director { get; private set; }
    
    public MovieReleaseDate ReleaseDate { get; private set; }
    
    public MovieBoxOffice BoxOffice { get; private set; }
    
    public MovieLength Length { get; private set; }
    
    public ICollection<MovieActor> Actors { get; private set; }
    
    public DateTimeOffset CreatedAt { get; private set; }   

    public Movie(MovieTitle title, MovieGenre genre, MovieDirector director, MovieReleaseDate releaseDate, MovieBoxOffice boxOffice, MovieLength length, ICollection<MovieActor> actors) : base()
    {
        Id = Guid.NewGuid();
        Title = title;
        Genre = genre;
        Director = director ?? throw new EmptyMovieDirectorException();
        ReleaseDate = releaseDate;
        BoxOffice = boxOffice;
        Length = length;
        Actors = actors;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    private Movie()
    {
        Actors = new List<MovieActor>();
    }

    public void UpdateTitle(MovieTitle title)
    {
        Title = title;
    }

    public void UpdateGenre(MovieGenre genre)
    {
        Genre = genre;
    }

    public void UpdateDirector(MovieDirector director)
    {
        Director = director ?? throw new EmptyMovieDirectorException();
    }
    
    public void UpdateReleaseDate(MovieReleaseDate releaseDate)
    {
        ReleaseDate = releaseDate;
    }
    
    public void UpdateBoxOffice(MovieBoxOffice boxOffice)
    {
        BoxOffice = boxOffice;
    }
    
    public void UpdateLength(MovieLength length)
    {
        Length = length;
    }

    public void UpdateActors(ICollection<MovieActor> actors)
    {
        throw new NotImplementedException();
    }
}