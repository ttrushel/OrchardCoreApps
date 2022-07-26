using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Movies",
    Author = "Tyler Trushel",
    Version = "0.0.1",
    Description = "Movies",
    Dependencies = new[] { "OrchardCore.Contents" },
    Category = "Content Management"
)]
