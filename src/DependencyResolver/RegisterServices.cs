using System;
using GoParty.Business.Contract.Events.Services;
using GoParty.Business.Contract.Geography.Services;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using GoParty.Business.Events.Services;
using GoParty.Business.Geography.Services;
using GoParty.Business.Users.Services;
using Microsoft.AspNet.Identity;
using Ninject;
using Ninject.Web.Common;
using Repository.Contexts;
using Repository.Contract.Repositories;
using Repository.Repositories;

namespace DependencyResolver
{
    public static class RegisterServices
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<GoPartyDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IUserPasswordStore<User, Guid>, IUserStore<User, Guid>>().To<UserService>().InRequestScope();
            kernel.Bind<UserManager<User, Guid>>().To<UserManager>().InRequestScope();
            kernel.Bind<IEventRepository>().To<EventRepository>().InRequestScope();
            kernel.Bind<IEventRetrievingService, IEventModifyingService>().To<EventService>().InRequestScope();
            kernel.Bind<ICityRepository>().To<CityRepository>().InRequestScope();
            kernel.Bind<IRegionRepository>().To<RegionRepository>().InRequestScope();
            kernel.Bind<ICountryRepository>().To<CountryRepository>().InRequestScope();
            kernel.Bind<ILocationRetrievingService>().To<LocationService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IUserRetrievingService, IUserModifyingService>().To<UserService>().InRequestScope();
            kernel.Bind<ISubscribeOnEventService>().To<SubscribeOnEventService>().InRequestScope();
        }
    }
}
