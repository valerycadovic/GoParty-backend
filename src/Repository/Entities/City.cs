namespace Repository.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual Region Region { get; set; }
    }
}
