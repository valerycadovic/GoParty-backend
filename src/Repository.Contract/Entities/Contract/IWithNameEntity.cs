using System;

namespace Repository.Contract.Entities.Contract
{
    public interface IWithNameEntity<T> : IEntity<T>, IWithName
        where T : IEquatable<T>
    {
    }

    public interface IWithUniqueNameEntity<T> : IWithNameEntity<T>
        where T : IEquatable<T>
    {
    }
}
