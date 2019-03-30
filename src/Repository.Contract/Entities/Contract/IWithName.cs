namespace Repository.Contract.Entities.Contract
{
    public interface IWithName
    {
        string Name { get; set; }
    }

    public interface IWithUniqueName : IWithName
    {
    } 
}
