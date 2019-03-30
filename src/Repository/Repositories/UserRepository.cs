using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class UserRepository : EntityRepository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(GoPartyDbContext context) : base(context)
        {
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            return await GetAll().SingleOrDefaultAsync(user => user.Login == username);
        }
    }
}
