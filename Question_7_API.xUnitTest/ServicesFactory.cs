using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Question_7_API.Data;
using Question_7_API.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question_7_API.xUnitTest
{
    internal static class ServicesFactory
    {
        internal static IMapper CreateMapper() => CreateAutoMapperConfiguration().CreateMapper();
        private static MapperConfiguration CreateAutoMapperConfiguration() =>
           new MapperConfiguration(mc => { mc.AddProfile(new MapProfile()); });
        internal static ApplicationDbContext CreateDb() =>
           new ApplicationDbContext(CreateNewContextOptions());

        private static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();


            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            object p = builder.UseInMemoryDatabase(Guid.NewGuid().ToString("N"))
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
