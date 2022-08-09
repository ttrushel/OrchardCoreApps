using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Orders.Models;
using System;
using System.Threading.Tasks;

namespace Orders.Settings
{
    public class DisplayPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!String.Equals(nameof(DisplayPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            return Initialize<DisplayPartSettingsViewModel>("DisplayPartSettings_Edit", model =>
            {
                var settings = contentTypePartDefinition.GetSettings<DisplayPartSettings>();

                model.MySetting = settings.MySetting;
                model.DisplayPartSettings = settings;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!String.Equals(nameof(DisplayPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            var model = new DisplayPartSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.MySetting))
            {
                context.Builder.WithSettings(new DisplayPartSettings { MySetting = model.MySetting });
            }

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}
