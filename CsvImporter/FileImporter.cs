using CsvImporter.Data.Models;

namespace CsvImporter
{
    /// <summary>
    /// Handles file imports.
    /// </summary>
    public class FileImporter : IFileImporter
    {
        private readonly IUIHandler _uiHandler;
        private readonly IInputValidator _inputValidator;
        private readonly IFileReader _fileReader;
        private readonly IDbHandler _dbHandler;
        private readonly VEHICLESContext _context;
        private readonly IInputGatherer _inputGatherer;

        public FileImporter(IUIHandler uIHandler, IInputValidator InputValidator, IFileReader fileReader, IDbHandler dbHandler, VEHICLESContext context, IInputGatherer inputGatherer)
        {
            _uiHandler = uIHandler ?? throw new ArgumentNullException(nameof(uIHandler), "UIHandler cannot be null.");
            _inputValidator = InputValidator ?? throw new ArgumentNullException(nameof(InputValidator), "InputValidator cannot be null.");
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader), "FileReader cannot be null.");
            _dbHandler = dbHandler ?? throw new ArgumentNullException(nameof(dbHandler), "DbHandler cannot be null.");
            _context = context ?? throw new ArgumentNullException("dbcontext cannot be null.");
            _inputGatherer = inputGatherer ?? throw new ArgumentNullException(nameof(inputGatherer), "InputGatherer cannot be null.");

        }

        public void ImportFile()
        {

            bool allFilesSavedOK = false;

            //get the users input and validate the file exist
            string path = _inputGatherer.GetUserFileNameAndValidateFile();

            //read the file and convert it to a list of vehicles
            List<Vehicle> vehicles = _fileReader.ReadFile(path);

            //save the vehicles to the database
            allFilesSavedOK = _dbHandler.SaveVehicles(vehicles, _context);

            //check everything was saved ok
            if (allFilesSavedOK)
            {
                _uiHandler?.WriteOutput("The CSV File has been successfully imported.");
                _uiHandler?.WriteOutput("All vehicles saved successfully to SQL Database.");
            }
            else
            {
                _uiHandler?.WriteOutput("There was an error saving the vehicles.");
            }

        }

       
    }
}
