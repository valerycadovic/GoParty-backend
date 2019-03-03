using System;

namespace Repository.Entities.Contract
{
    public interface IEntity<T> where T : struct, IComparable<T>
    {
        T Id { get; set; }
    }
}
