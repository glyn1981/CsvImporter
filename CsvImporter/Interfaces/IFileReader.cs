using CsvImporter.Data.Models;

namespace CsvImporter
{
    /// <summary>
    /// Interface for reading files and converting lines to Vehicle objects.
    /// </summary>
    public interface IFileReader
    {
        List<Vehicle> ConvertLinesToVehicles(List<string> stringItems);
        List<Vehicle> ReadFile(string FileName);
    }
}