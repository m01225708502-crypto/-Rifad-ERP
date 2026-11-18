using Microsoft.Data.Sqlite;

namespace Rifad.ERP.Data;

internal static class DatabaseInitializer
{
    private static readonly string DataDirectory =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RifadERP");

    public static string DatabasePath => Path.Combine(DataDirectory, "rifad.db");

    public static void Initialize()
    {
        Directory.CreateDirectory(DataDirectory);

        using var connection = new SqliteConnection($"Data Source={DatabasePath}");
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            PRAGMA foreign_keys = ON;
            CREATE TABLE IF NOT EXISTS AppInfo (
                Id INTEGER PRIMARY KEY CHECK (Id = 1),
                ProductName TEXT NOT NULL,
                DatabaseVersion INTEGER NOT NULL
            );
            INSERT OR IGNORE INTO AppInfo (Id, ProductName, DatabaseVersion)
            VALUES (1, 'Rifad ERP', 1);
            """;
        command.ExecuteNonQuery();
    }
}
