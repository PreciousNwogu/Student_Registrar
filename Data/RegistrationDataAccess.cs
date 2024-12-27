using Dapper;

namespace Registrar;

public class RegistrationDataAccess : IDataAccess<Registration>
{
    private readonly Database db;
    public RegistrationDataAccess (Database database) 
    {
      db = database;
    }

    public Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

		public async Task DeleteCourses(int studentId)
		{
			using (var connection = db.Connect())
			{
				var sql = "DELETE FROM Registration WHERE StudentId = @studentId";
				await connection.ExecuteAsync(sql, new { studentId });
			}
		}

    public Task<Registration> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Registration>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<List<int>> GetCourses(int studentId)
    {
        using (var connection = db.Connect())
        {
            var sql = "SELECT CourseId FROM Registration WHERE StudentId = @studentId";
            var rows = await connection.QueryAsync<int>(sql, new { studentId });
            return rows.ToList();
        }
    }

    public async Task RegisterCourses (List<Registration> registrations)
    {
      using (var connection = db.Connect())
      {	
				await DeleteCourses(registrations[0].StudentId);
				
        foreach (var registration in registrations)
        {
            await Store(registration);
        }
      }
    }
 
    public async Task<int> Store(Registration registration)
    {
      using (var connection = db.Connect())
      {
        var sql = "INSERT INTO Registration (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
        return await connection.ExecuteAsync(sql, registration);
      }
    }

    public Task<int> Update(int id, Registration t)
    {
        throw new NotImplementedException();
    }
}
