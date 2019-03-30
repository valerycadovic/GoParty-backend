using System;
using System.Threading.Tasks;

namespace GoParty.Business.Contract.Core.Services
{
    public interface IRetrievingService<TModel> 
        where TModel : class 
    {
        Task<TModel> Get(Func<TModel, bool> filter);
    }
}
