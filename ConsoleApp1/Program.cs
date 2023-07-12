using Npgsql;


NpgSqlHelper npgSqlHelper = new NpgSqlHelper("Server=localhost;port=5432;User Id = postgres;Password=7788;Database=test");

npgSqlHelper.CreateTable("Books", "Id int primary key, BookName varchar(50), Author varchar(50),BookPage int");
npgSqlHelper.Insert("Books", "1,'Otkan kular','Adbulla Qodiriy'230");
npgSqlHelper.Select("Books");


public interface IDatabaseHelper
{
    void CreateTable(string tableName, string columns);
    void Insert(string tableName, string values);
    void Update(string tableName, string column, string value, string condition);
    void AlterTable(string tableName, string alteration);
    void Delete(string tableName, string condition);
    void Select(string tableName);
}

public class NpgSqlHelper : IDatabaseHelper
{
    private string connectionString;

    public NpgSqlHelper(string connString)
    {
        connectionString = connString;
    }

    public void CreateTable(string tableName, string columns)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"CREATE TABLE IF NOT EXISTS {tableName} ({columns})";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void Insert(string tableName, string values)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"INSERT INTO {tableName} VALUES ({values})";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                
                command.ExecuteNonQuery();
            }
        }
    }

    public void Update(string tableName, string column, string value, string condition)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"UPDATE {tableName} SET {column} = {value} WHERE {condition}";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void AlterTable(string tableName, string alteration)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"ALTER TABLE {tableName} {alteration}";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(string tableName, string condition)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"DELETE FROM {tableName} WHERE {condition}";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void Select(string tableName)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = $"Insert *  from {tableName}";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}



