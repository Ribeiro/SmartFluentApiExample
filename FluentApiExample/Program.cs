

namespace FluentApiExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connection = FluentSqlConnection.CreateConnection()
                                                .ForServer("localhost")
                                                .AndDatabase("mydb")
                                                .AsUser("gigio")
                                                .WithPassword("passwd")
                                                .Connect();
        }
    }
}
