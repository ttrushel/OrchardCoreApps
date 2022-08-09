using OrchardCore.ContentManagement.Handlers;
using Showings.Models;
using System.Threading.Tasks;

namespace Showings.Handlers
{
    public class DisplayPartHandler : ContentPartHandler<DisplayPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, DisplayPart part)
        {
            part.Show = true;

            return Task.CompletedTask;
        }
    }
}