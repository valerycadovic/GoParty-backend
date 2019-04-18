using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.UserContacts.Models;
using GoParty.Business.Contract.UserContacts.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.UserContacts.Services
{
    public class ContactsService : IContactsRetrievingService
    {
        private readonly IContactRepository _contactRepository;

        public ContactsService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetUserContacts(Guid userId)
        {
            var contacts = _contactRepository.Get(c => c.User.Id == userId);

            return await contacts.Select(n => Mapper.Map<ContactEntity, Contact>(n)).ToListAsync();
        }
    }
}
