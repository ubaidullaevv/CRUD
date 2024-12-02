namespace Infrascructor;


using Npgsql;
using NpgsqlService;



public class MovieService:IMovieService
{
        public void AddMovie(Movie movie)
        {
           string connectionString =$@"Server=localhost;Port=5432;Database=movies;Username=postgres;Password=12345;";
           using (var connection = new NpgsqlConnection (connectionString))
           connection.Open();
           var command = new NpgsqlCommand(connection)
           command.CommandText = "insert into movies (title,director,rating,genre,realisyear) values (@title,@director,@rating,@genre,@realisyear)";
           command.Parameters.AddWithValue("@title",movie.Title);
           command.Parameters.AddWithValue("@director",movie.Director);
           command.Parameters.AddWithValue("@rating",movie.Rating);
           command.Parameters.AddWithValue("@genre",movie.genre);
           command.Parameters.AddWithValue("@realisyear",movie.realisyear);
           command.ExecuteNonQuery();

        }
    public bool UpdateMovie(Movie movie)
    {

    }
    public bool DeleteMovie(int id)
    {
        
    }
    public void DisplayMovies()
    {
        string connectionString = $@"Server=localhost;Port=5432;Database=movies;Username=postgres;Password=12345;"
        using (var command = new NpgsqlCommand(connectionString))
        {
            command.Open();
            using(var cmd=new NpgsqlCommand("Select * from movies;",command))
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(new Movie()
                    {
                        Id=reader.GetInt32(0),
                        Title=reader.GetString(1),
                        Direcor=reader.GetString(2),
                        RealisYear=reader.GetInt32(3),
                        Genre=reader.GetString(4),
                        Ratin=reader.GetDouble(5),

                    })
                }
            }
        }
    }
}














