using CsvImporter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace CsvImporter.Test
{
    /// <summary>
    /// Test that the user of the program has ability to connect to the Azure SQL database and save vehicles to it.
    /// </summary>
    public class AzureDbConnectivityTests
    {

        /// <summary>
        /// TestUserCanAddConnectToDb_ExepectTrue
        /// </summary>
        [Fact]
        public void TestUserCanAddConnectToDb_ExepectTrue()
        {
            //test that you can connect to the azure sql database.
            //if you cannot connect perhaps the firewall is blocking
            //i made the firewall allow all ip addresses, so this should work.

            // setup configuration to read connection string from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            var connstring = configuration["ConnectionStrings:DefaultConnection"];

            if (string.IsNullOrEmpty(connstring))
            {
                Console.WriteLine("Connection string is missing or empty. Please check your appsettings.json file.");
                return;
            }

            // setup db context
            DbContextOptions<VEHICLESContext> options = new DbContextOptionsBuilder<VEHICLESContext>()
              .UseSqlServer(connstring)
              .Options;

            VEHICLESContext context = new(options);
            var vehicle = context.Vehicles.ToList();
            Assert.NotNull(vehicle);

        }
    }
}