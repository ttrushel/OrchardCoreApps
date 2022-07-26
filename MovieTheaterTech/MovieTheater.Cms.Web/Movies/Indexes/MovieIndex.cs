using Movies.Models;
using YesSql.Indexes;

namespace Movies.Indexes
{
    public class MovieIndex : MapIndex
    {
        public string Title { get; set; }
    }

    public class MovieIndexProvider : IndexProvider<MoviePart>
    {
        public override void Describe(DescribeContext<MoviePart> context) =>
            context.For<MovieIndex>()
                .Map(movie =>
                    new MovieIndex
                    {
                        Title = movie.Title
                    });
    }
}
