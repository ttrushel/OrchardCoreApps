using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Movies.Drivers;
using Movies.Handlers;
using Movies.Indexes;
using Movies.Migrations;
using Movies.Models;
using Movies.ViewModels;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using System;
using YesSql.Indexes;

namespace Movies
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<MoviePartViewModel>();
            });

            services.AddContentPart<MoviePart>()
                .UseDisplayDriver<MoviePartDisplayDriver>()
                .AddHandler<MoviePartHandler>();

            services.AddScoped<IDataMigration, MoviesMigrations>();
            services.AddSingleton<IIndexProvider, MovieIndexProvider>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Movies",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
