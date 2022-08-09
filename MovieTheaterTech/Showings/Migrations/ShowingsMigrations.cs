using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Showings.Migrations
{
    public class ShowingsMigrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public ShowingsMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("Showing", t => t
                .Creatable()
                .Listable()
                .Versionable());

            return 1;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition("Movie", t => t
                .Creatable()
                .Listable());

            return 2;
        }
    }
}
