using System.Data;
using MySql.Data.MySqlClient;

namespace Registrar;

public class Database (string connectionString)
{
  private readonly string connectionString = connectionString;

  public IDbConnection Connect ()
  {
    return new MySqlConnection(connectionString);
  }
}
