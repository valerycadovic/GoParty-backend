using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.UserContacts.Models;

namespace GoParty.Business.Contract.UserContacts.Services
{
    public interface IContactsRetrievingService
    {
        Task<List<Contact>> GetUserContacts(Guid userId);
    }
}
