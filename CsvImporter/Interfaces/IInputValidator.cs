namespace CsvImporter
{
    /// <summary>
    /// Interface for the input validator.
    /// </summary>
    public interface IInputValidator
    {
        bool ValidateInput(string? input);
    }
}