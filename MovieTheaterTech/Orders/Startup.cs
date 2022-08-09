using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using Orders.Migrations;
using System;

namespace Orders
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<TemplateOptions>(o =>
            //{
            //    o.MemberAccessStrategy.Register<DisplayPartViewModel>();
            //});

            //services.AddContentPart<DisplayPart>()
            //    .UseDisplayDriver<DisplayPartDisplayDriver>()
            //    .AddHandler<DisplayPartHandler>();

            //services.AddScoped<IContentTypePartDefinitionDisplayDriver, DisplayPartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, OrdersMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Orders",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
