var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("Cleric"); 

builder.AddProject<Projects.Cleric_Web>("cleric-web")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
