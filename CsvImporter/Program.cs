using CsvImporter;
using CsvImporter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CsvImporter.Test")]
internal class Program
{

    public static void Main()
    {
        // setup configuration file
        IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

        // setup the connection string from the configuration file
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

        // setup dependencies for injection.  
        VEHICLESContext context = new(options);
        IUIHandler uIHandler = new UIHandler();
        InputValidator inputValidator = new InputValidator(uIHandler);
        IFileReader reader = new FileReader();
        IDbHandler dbHandler = new DbHandler();
        IInputGatherer inputGatherer = new InputGatherer(uIHandler, inputValidator);
        IFileImporter fileImporter = new FileImporter(uIHandler, inputValidator, reader, dbHandler, context, inputGatherer);

        // start the process of importing the file
        uIHandler.WriteOutput("Welcome to the CSV Importer Application!");
        uIHandler.WriteOutput("Please follow the prompts to import your CSV file.");

        try
        {
            // import the file
            fileImporter.ImportFile();
        }
        catch (Exception ex)
        {
            uIHandler.WriteOutput($"An error occurred: {ex.Message}");
        }
    }
}
