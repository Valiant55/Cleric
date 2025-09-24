var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("Cleric");

var dbUp = builder.AddProject<Projects.Cleric_Database>("cleric-database")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.Cleric_Web>("cleric-web")
    .WithReference(db)
    .WaitFor(dbUp);

builder.Build().Run();
