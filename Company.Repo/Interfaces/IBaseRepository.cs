using Company.Data.Models;

namespace Company.Repo.Interfaces;

public interface IBaseRepository<T> where T : ModelMetadata
{
    T? GetById(int id);

    IEnumerable<T> GetAll();

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}
