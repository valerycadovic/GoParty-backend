using System;

namespace Repository.Entities.Contract
{
    public interface IWithNameEntity<T> : IEntity<T> where T : struct, IComparable<T>
    {
        string Name { get; set; }
    }
}
