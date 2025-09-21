var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Cleric_Web>("cleric-web");

builder.Build().Run();
