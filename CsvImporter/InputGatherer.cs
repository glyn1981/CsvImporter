
namespace CsvImporter
{
    public class InputGatherer : IInputGatherer

    {
        private readonly IUIHandler _uiHandler;
        private readonly IInputValidator _inputValidator;

        public InputGatherer(IUIHandler uiHandler, IInputValidator inputValidator)
        {
            _uiHandler = uiHandler;
            _inputValidator = inputValidator;
        }

        public string GetUserFileNameAndValidateFile()
        {
            string path = _uiHandler.GetInput("Enter the path to the CSV file");
            {
                // Validate the input file path
                bool validFile = false;
                validFile = _inputValidator.ValidateInput(path);

                if (!validFile)
                {
                    // If the file is not valid, prompt the user again
                    _uiHandler.WriteOutput("The file path is invalid. Re-Run the application to try again.");

                    //return empty string to indicate failure
                    //needed for integration testing otherwise we get stuck in a loop.
                    return string.Empty;
             
                }
                return path;
            }
        }
    }

}

