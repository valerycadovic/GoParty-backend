using System;
using System.Linq;
using AutoMapper;

namespace GoParty.Web
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => assembly.FullName.StartsWith("GoParty.")).ToArray();

                cfg.AddProfiles(assemblies);
            });
        }
    }
}