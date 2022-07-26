using System.Threading.Tasks;

namespace Movies.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> MovieIsInTheatersAsync(string movie);
        Task<bool> SaveMovieAsync(string movie);
    }
}
