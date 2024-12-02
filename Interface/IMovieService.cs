namespace Infrascructor;

public interface IMovieService
{
    public void AddMovie(Movie movie);
    public bool UpdateMovie(Movie movie);
    public bool DeleteMovie(int id);
    public void DisplayMovies();
}