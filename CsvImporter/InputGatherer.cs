
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
                    _uiHandler.WriteOutput("The file path is invalid. Please try again.");
                    return GetUserFileNameAndValidateFile();
                }
                return path;
            }
        }
    }

}

