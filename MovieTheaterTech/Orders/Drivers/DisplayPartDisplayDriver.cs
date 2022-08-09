using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Orders.Models;
using Orders.Settings;
using Orders.ViewModels;
using System.Threading.Tasks;

namespace Orders.Drivers
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
                model.ContentItem = part.ContentItem;
                model.DisplayPart = part;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(DisplayPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show);

            return Edit(model);
        }

        private Task BuildViewModel(DisplayPartViewModel model, DisplayPart part, BuildPartDisplayContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<DisplayPartSettings>();

            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
            model.DisplayPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
