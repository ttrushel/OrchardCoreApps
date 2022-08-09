using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Orders.Migrations
{
    public class OrdersMigrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public OrdersMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("Order", t => t
                .Creatable()
                .Listable()
                .Securable());

            return 1;
        }
    }
}
