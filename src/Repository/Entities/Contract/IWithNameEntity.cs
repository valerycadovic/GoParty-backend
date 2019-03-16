using System;

namespace Repository.Entities.Contract
{
    public interface IWithNameEntity<T> : IEntity<T>, IWithName
        where T : struct, IComparable<T>
    {
    }
}
