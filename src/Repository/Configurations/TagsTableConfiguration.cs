using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class TagsTableConfiguration : WithNameTableConfiguration<Tag, int>
    {
        public TagsTableConfiguration() : base("Tags")
        {
        }
    }
}
