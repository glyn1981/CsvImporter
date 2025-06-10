namespace CsvImporter
{
    using System.IO;

    /// <summary>
    /// Validates user input for the CSV importer application.
    /// </summary>
    public class InputValidator : IInputValidator

    {
        private readonly IUIHandler _uIHandler;
        public InputValidator(IUIHandler uIHandler)
        {
            _uIHandler = uIHandler ?? throw new ArgumentNullException(nameof(uIHandler), "UIHandler cannot be null.");
        }

        public bool ValidateInput(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                _uIHandler.WriteOutput($"{input} cannot be empty. please try again.");
                return false;
            }
            if (!File.Exists(input))
            {
                _uIHandler.WriteOutput($"{input} the file specified does not exist, please try again.");
                return false;
            }

            return true;
        }

    }
}
