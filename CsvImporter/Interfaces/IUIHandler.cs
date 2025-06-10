namespace CsvImporter
{
    /// <summary>
    /// an intereface for handling user input and output in the console application.
    /// </summary>
    public interface IUIHandler
    {
        string GetInput(string? prompt = null);
        void WriteOutput(string? output = null);
    }
}