using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Showings",
    Author = "Tyler Trushel",
    Version = "0.0.1",
    Description = "Movie showing management.",
    Dependencies = new[] { "OrchardCore.Contents" },
    Category = "Content Management"
)]
