using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class EventRepository : EntityRepository<EventEntity, Guid>, IEventRepository
    {
        public EventRepository(GoPartyDbContext context) : base(context)
        {
        }
    }
}
