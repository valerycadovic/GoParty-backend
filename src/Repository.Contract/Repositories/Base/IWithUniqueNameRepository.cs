using System.Threading.Tasks;

namespace Repository.Contract.Repositories.Base
{
    public interface IWithUniqueNameRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        Task<TEntity> GetByNameAsync(string name);
    }
}
