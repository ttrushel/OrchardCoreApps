using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Orders",
    Author = "Tyler Trushel",
    Version = "0.0.1",
    Description = "Online order management.",
    Dependencies = new[] { "OrchardCore.Contents" },
    Category = "Content Management"
)]
