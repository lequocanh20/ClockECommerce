using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace clbTinHoc.Data.EF
{
    public class clockECommerceDbContextFactory : IDesignTimeDbContextFactory<clockECommerceDbContext>
    {
        public clockECommerceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("clockECommerceDb");

            var optionsBuilder = new DbContextOptionsBuilder<clockECommerceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new clockECommerceDbContext(optionsBuilder.Options);
        }
    }
}
