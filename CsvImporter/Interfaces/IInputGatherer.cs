namespace CsvImporter
{
    /// <summary>
    /// interface for the input gatherer.
    /// </summary>
    public interface IInputGatherer
    {
        string GetUserFileNameAndValidateFile();
    }
}