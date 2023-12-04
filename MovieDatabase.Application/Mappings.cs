using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Entities;

namespace MovieDatabase.Application;

public static class Mappings
{
    public static MovieDto AsDto(this Movie movie) => new (movie.Id, movie.Title, movie.Genre, movie.Director.Id, movie.ReleaseDate, movie.BoxOffice, movie.Length, movie.Actors.Select(x => x.Id.Value));
}