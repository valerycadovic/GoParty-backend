using System;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;
using Repository.Repositories.Base;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IKernel Kernel;

        static void Main(string[] args)
        {
            Do().Wait();
        }

        static async Task Do()
        {
            using (var context = Kernel.Get<GoPartyDbContext>())
            {
                var user = new UserEntity
                {
                    Name = "Valery Chadovich",
                    City = context.Cities
                        .Single(c => c.Name == "Nesvizh"),
                    Login = "valerycadovic",
                    Password = "valera",
                    Email = "valery.cadovic@gmail.com"
                };

                var repo = Kernel.Get<IRepository<UserEntity>>();

                await repo.AddAsync(user);

                await context.SaveChangesAsync();

                var users = await repo.GetAllAsync();

                foreach (var group in users.GroupBy(u => u.City.Name))
                {
                    Console.WriteLine(group.Key);
                    Console.WriteLine();
                    foreach (var item in group)
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.WriteLine("---------------------------------------------");
                }
            }

            Console.ReadKey();
        }

        static Program()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IRepository<UserEntity>>().To<Repository<UserEntity>>();
            Kernel.Bind<GoPartyDbContext>().ToSelf().InSingletonScope();
        }
    }
}
