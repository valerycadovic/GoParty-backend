namespace GoParty.Business.Contract.Core.Services
{
    public interface IMapper<in TSource, out TResult>
    {
        TResult Map(TSource source);
    }
}
