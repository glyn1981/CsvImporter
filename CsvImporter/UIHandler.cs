
namespace CsvImporter
{
    /// <summary>
    /// Handles user input and output to the console.
    /// </summary>
    public class UIHandler : IUIHandler

    {
        public string GetInput(string? prompt = null)
        {

            if (!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine(prompt);
            }
            return Console.ReadLine() ?? string.Empty;

        }

        public void WriteOutput(string? output = null)
        {
            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine(output);
            }
        }
    }
}
