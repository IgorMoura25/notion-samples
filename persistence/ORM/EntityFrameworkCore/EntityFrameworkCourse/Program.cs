using EntityFrameworkCourse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

EnsureCreated();
HealthCheckDatabase();

static void HealthCheckDatabase()
{
    using var db = new ApplicationContext();

    if (db.Database.CanConnect())
    {
        Console.WriteLine("Posso me conectar");
    }
    else
    {
        Console.WriteLine("Não posso me conectar");
    }
}

static void EnsureCreated()
{
    using var db1 = new ApplicationContext();
    //using var db2 = new OutroContext();

    db1.Database.EnsureCreated();

    // Somente se estiver usando esse método com mais de 1 contexto diferente
    //db2.Database.EnsureCreated();
    // IRelationalDatabaseCreator databaseCreator = db2.GetService<IRelationalDatabaseCreator>();
    // databaseCreator.CreateTables();
}

static void ExecuteSql()
{
    using var db = new ApplicationContext();

    // Primeira opção
    using (var cmd = db.Database.GetDbConnection().CreateCommand())
    {
        cmd.CommandText = "SELECT 1";
        cmd.ExecuteNonQuery();
    }

    // Segunda opção com DbParameters evitando SQL Injection
    var description = "TESTE";
    db.Database.ExecuteSqlRaw("UPDATE Departments SET Description = {0} WHERE Id = 1", description);

    // Terceira opção
    db.Database.ExecuteSqlInterpolated($"UPDATE Departments SET Description = {description} WHERE Id = 1");
}
