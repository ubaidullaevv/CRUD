public static class NpgsqlServices
{
    public static void CreateDB(string databaseName)
    {
        string connectionString = @"Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345;";
        using (var connecton = new NpgsqlConnection(connectionString))
        {
            connecton.Open();
            using (var cmd = new NpgsqlCommand($"CREATE DATABASE {databaseName};", connecton))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
    public static void CreateTable(string databaseName, string tableName, string[] columnDefinitions)
{
    string connectionString = $@"Server=localhost;Port=5432;Database={databaseName};Username=postgres;Password=12345;";
    using (var connecton = new NpgsqlConnection(connectionString))
    {
        connecton.Open();
        string columns = string.Join(", ", columnDefinitions); 
        string createTableQuery = $@"
            CREATE TABLE IF NOT EXISTS {tableName} 
                                        (
                                        {columns}
                                         );";
        using (var cmd = new NpgsqlCommand(createTableQuery, connecton))
        {
            cmd.ExecuteNonQuery();
        }
    }
}
    public static void InsertMovie(Movie movie, string databaseName)
    {
         string connectionString = @"Server=localhost;Port = 5432;Database=" + databaseName + ";Username=postgres;Password=12345;";
        using (var connecton = new NpgsqlConnection(connectionString))
        {
            connecton.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO movies (title, author, genre, publication_date) VALUES (@Title, @Author, @Genre, @PublicationDate);"))
            {
                cmd.Parameters.AddWithValue("Title", movie.Title);
                cmd.Parameters.AddWithValue("ReleaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("Director", movie.Director);
                cmd.Parameters.AddWithValue("Genre", movie.Genre);
                cmd.Parameters.AddWithValue("Rating", movie.Rating);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public static List<Movie> Getmovies(string databaseName)
    {
        List<Movie> movies = new List<Movie>();
        string connectionString = @"Server=localhost;Port = 5432;Database=" + databaseName + ";Username=postgres;Password=12345;";
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT * FROM movies;", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(new movie
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        Genre = reader.GetString(3),
                        PublishedYear = reader.GetDateTime(4)
                    });
                }
            }
        }
        return movies;
    }
    public static void Updatemovie(Movie movie, string databaseName)
    {
        string connectionString = @"Server=localhost;Port = 5432;Database=" + databaseName + ";Username=postgres;Password=12345;";
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("UPDATE movies SET title=@Title, director=@director, genre=@Genre, realisyear=@realisyear WHERE id=@Id;", connecton))
            {
                cmd.Parameters.AddWithValue("Title", movie.Title);
                cmd.Parameters.AddWithValue("Direcor", movie.Direcor);
                cmd.Parameters.AddWithValue("Genre", movie.Genre);
                cmd.Parameters.AddWithValue("RealisYear", movie.RealisYear);
                cmd.Parameters.AddWithValue("Id", movie.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public static void Deletemovie(int id, string databaseName)
    {

        string connectionString = @"Server=localhost;Port = 5432;Database=" + databaseName + ";Username=postgres;Password=12345;";
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM movies WHERE id=@Id;", conn))
            {
                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
