using AutoMapper;
using ContactsView = GoParty.Business.Contract.UserContacts.Models.Contacts;
using ContactsData = Repository.Contract.Entities.ContactEntity;

namespace GoParty.Business.Contacts.Mappings
{
    public class ContactsMapping : Profile
    {
        public ContactsMapping()
        {

        }
    }
}
