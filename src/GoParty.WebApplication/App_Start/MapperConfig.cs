using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace GoParty.WebApplication.App_Start
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