using Movies.Models;
using Movies.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Movies.Drivers
{
    public class MoviePartDisplayDriver : ContentPartDisplayDriver<MoviePart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public MoviePartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(MoviePart part, BuildPartDisplayContext context)
        {
            return Initialize<MoviePartViewModel>(GetDisplayShapeType(context), vm => BuildViewModel(vm, part, context))
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10")
                ;
        }

        public override IDisplayResult Edit(MoviePart part, BuildPartEditorContext context)
        {
            return Initialize<MoviePartViewModel>(GetEditorShapeType(context), model =>
            {
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(MoviePart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix);
            return Edit(model);
        }

        private Task BuildViewModel(MoviePartViewModel model, MoviePart part, BuildPartDisplayContext context)
        {
            return Task.CompletedTask;
        }
    }
}
