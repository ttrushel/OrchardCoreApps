using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Employees",
    Author = "Tyler Trushel",
    Version = "0.0.1",
    Description = "Employee management.",
    Dependencies = new[] { "OrchardCore.Contents" },
    Category = "Content Management"
)]
