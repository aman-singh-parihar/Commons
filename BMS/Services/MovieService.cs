using BMS.Data;

namespace BMS.Services
{
    public class MovieService
    {
        public List<Movie> GetMovies(string? genre, string? title) 
        {
            if (!string.IsNullOrEmpty(genre) || !string.IsNullOrEmpty(title))
            {
                return DummyDataSeeder.Movies()
                    .Where(m => (string.IsNullOrEmpty(genre) || m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) &&
                                (string.IsNullOrEmpty(title) || m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            return DummyDataSeeder.Movies();
        }
    }
}
