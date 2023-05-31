using System.Linq.Expressions;
using OOP.Domain.Models;

namespace OOP.Service.ICustomServices;

public interface ICustomService<T> where T: BaseEntity
{
    public Task<List<T>> GetAllAsync();
    public Task<List<T>> GetByFilter(Expression<Func<T,bool>> filter);
    public Task<T> GetAsync(string id);
    public Task UpdateAsync(string id, T entity);
    public Task InsertAsync(T entity);
    public Task RemoveAsync(string id);

    public Task<long> Count();
}