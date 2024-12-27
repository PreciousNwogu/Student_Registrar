using Dapper;
namespace Registrar;

public class CourseDataAccess : IDataAccess<Course>
{
    private readonly Database db;

    public CourseDataAccess(Database database)
    {
        db = database;
    }

    public Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Course>> GetAll()
    {
      using (var connection = db.Connect()) 
      {
        var sql = "SELECT * FROM Course";
        var rows = await connection.QueryAsync<Course>(sql);
        return rows.ToList();
      }
    }

    public Task<int> Store(Course t)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(int id, Course t)
    {
        throw new NotImplementedException();
    }
}
