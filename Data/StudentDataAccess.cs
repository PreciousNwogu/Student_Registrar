
using Dapper;

namespace Registrar;

public class StudentDataAccess : IDataAccess<Student>
{
    private readonly Database db;
    public StudentDataAccess (Database database) 
    {
      db = database;
    }
    public async Task<List<Student>> GetAll()
    {
        using (var connection = db.Connect()) 
        {
          var sql = "SELECT * FROM Student";
          var rows = await connection.QueryAsync<Student>(sql);
          return rows.ToList();
        }
    }

    public async Task<Student> Get(int id)
    {
      try {
        using (var connection = db.Connect()) 
        {
          var sql = "SELECT * FROM Student WHERE id = @id";
          return await connection.QuerySingleAsync<Student>(sql, new { id });
        }
      } catch (InvalidOperationException) {
        throw;
      }   
    }

    public async Task<int> Store(Student student)
    {
      var sql = "INSERT INTO Student (Id, FirstName, LastName, Type) VALUES (@Id, @FirstName, @LastName, @Type)";
      
      using (var connection = db.Connect())
      {
        return await connection.ExecuteAsync(sql, student);
      }
    }

    public Task<int> Update(int id, Student student)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int id)
    {
      var sql = "DELETE FROM Student WHERE Id = @id";
      using (var connection = db.Connect())
      {
        return connection.ExecuteAsync(sql, new { id });
      }
    }
}
