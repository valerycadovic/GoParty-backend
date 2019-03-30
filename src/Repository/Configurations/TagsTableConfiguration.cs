using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class TagsTableConfiguration : WithUniqueNameTableConfiguration<TagEntity, int>
    {
        public TagsTableConfiguration() : base("Tags")
        {
        }
    }
}
