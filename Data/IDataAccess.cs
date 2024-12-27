namespace Registrar;

public interface IDataAccess<T>
{
  public Task<List<T>> GetAll();
  public Task<T> Get(int id);
  public Task<int> Store(T t);
  public Task<int> Update(int id, T t);
  public Task<int> Delete(int id);

}
