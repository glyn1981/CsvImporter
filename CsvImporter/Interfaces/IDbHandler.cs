
using CsvImporter.Data.Models;

namespace CsvImporter
{
    /// <summary>
    /// Interface for handling database operations related to vehicles.
    /// </summary>
    public interface IDbHandler
    {
        bool SaveVehicles(List<Data.Models.Vehicle> vehicles, VEHICLESContext context);
    }
}