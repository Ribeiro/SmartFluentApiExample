using System;
using System.Data;
using System.Data.SqlClient;


namespace FluentApiExample
{
    public class FluentSqlConnection : IserverSelectionStage, IDatabaseSelectionStage, IUserSelectionStage, IPasswordSelectionStage, IConnectionInitializerStage
    {
        private string _server;
        private string _database;
        private string _user;
        private string _password;

        private FluentSqlConnection() { }

        public static IserverSelectionStage CreateConnection(Action<ConnectionConfiguration> config)
        {

            return new FluentSqlConnection();
        }

        public IUserSelectionStage AndDatabase(string database)
        {
            _database = database;
            return this;
        }

        public IPasswordSelectionStage AsUser(string user)
        {
            _user = user;
            return this;
        }

        public IDbConnection Connect()
        {
            var connection = new SqlConnection($"Server={_server};Database={_database};User Id={_user};Password={_password}");
            return connection;
        }

        public IDatabaseSelectionStage ForServer(string server)
        {
            _server = server;
            return this;
        }

        public IConnectionInitializerStage WithPassword(string password)
        {
            _password = password;
            return this;
        }
    }

    public class ConnectionConfiguration
    {
        public string ConnectionName { get; set; }
    }

    public interface IserverSelectionStage
    {
        public IDatabaseSelectionStage ForServer(string server);
    }

    public interface IDatabaseSelectionStage
    {
        public IUserSelectionStage AndDatabase(string database);
    }

    public interface IUserSelectionStage
    {
        public IPasswordSelectionStage AsUser(string user);  
    }

    public interface IPasswordSelectionStage
    {
        public IConnectionInitializerStage WithPassword(string password);
    }

    public interface IConnectionInitializerStage
    {
        public IDbConnection Connect();
    }

}