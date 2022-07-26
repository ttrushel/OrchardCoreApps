using Movies.Indexes;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace Movies.Migrations
{
    public class MoviesMigrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public MoviesMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("MoviePart", builder => builder
                .Attachable()
                .WithDescription("Provides a Movie part for your content item."));

            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.CreateMapIndexTable<MovieIndex>(table => table
                .Column<string>(nameof(MovieIndex.Title), column => column.Unlimited()));
            return 2;
        }
    }
}
// NEXT STATION: Controllers/DatabaseStorageController and go to the CreateBooksPost action where we previously left.
