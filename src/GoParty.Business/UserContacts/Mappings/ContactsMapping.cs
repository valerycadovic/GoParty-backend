using AutoMapper;
using ContactsView = GoParty.Business.Contract.UserContacts.Models.Contact;
using ContactsData = Repository.Contract.Entities.ContactEntity;

namespace GoParty.Business.UserContacts.Mappings
{
    public class ContactsMapping : Profile
    {
        public ContactsMapping()
        {
            CreateMap<ContactsData, ContactsView>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(e => e.ContactType));
        }
    }
}
