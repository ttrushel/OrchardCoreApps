using OrchardCore.ContentManagement.Handlers;
using Orders.Models;
using System.Threading.Tasks;

namespace Orders.Handlers
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