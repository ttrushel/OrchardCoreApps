using Employees.Models;
using Employees.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Employees.Drivers
{
    public class DisplayPartDisplayDriver : ContentPartDisplayDriver<DisplayPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public DisplayPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(DisplayPart part, BuildPartDisplayContext context)
        {
            return Initialize<DisplayPartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, part, context))
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10")
                ;
        }

        public override IDisplayResult Edit(DisplayPart part, BuildPartEditorContext context)
        {
            return Initialize<DisplayPartViewModel>(GetEditorShapeType(context), model =>
            {
                model.Show = part.Show;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(DisplayPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show);

            return Edit(model);
        }

        private Task BuildViewModel(DisplayPartViewModel model, DisplayPart part, BuildPartDisplayContext context)
        {
            return Task.CompletedTask;
        }
    }
}
