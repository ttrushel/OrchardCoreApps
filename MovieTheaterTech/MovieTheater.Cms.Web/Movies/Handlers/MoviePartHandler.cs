using Movies.Models;
using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;

namespace Movies.Handlers
{
    public class MoviePartHandler : ContentPartHandler<MoviePart>
    {
        public override Task InitializingAsync(InitializingContentContext context, MoviePart part)
        {
            return Task.CompletedTask;
        }
    }
}