using Employees.Models;
using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;

namespace Employees.Handlers
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