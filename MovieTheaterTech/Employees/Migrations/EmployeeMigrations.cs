using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Employees.Migrations
{
    public class EmployeeMigrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public EmployeeMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("Employee", type => type
                .Creatable()
                .Listable());

            return 1;
        }
    }
}
