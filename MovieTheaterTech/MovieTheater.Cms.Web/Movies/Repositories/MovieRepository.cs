using Movies.Indexes;
using Movies.Models;
using System;
using System.Threading.Tasks;
using YesSql;

namespace Movies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ISession _session;
        public MovieRepository(ISession session)
        {
            _session = session;
        }
        public async Task<bool> MovieIsInTheatersAsync(string movie)
        {
            var record = await _session
                .Query<MoviePart, MovieIndex>()
                .Where(index => index.Title.ToLower().Equals(movie.ToLower()))
                .FirstOrDefaultAsync();

            return record != null
                ? true
                : false;
        }
        public async Task<bool> SaveMovieAsync(string movie)
        {
            var movieRecord = new MoviePart { Title = movie };
            _session.Save(movieRecord);
            await _session.SaveChangesAsync();
            return true;
        }
    }
}
