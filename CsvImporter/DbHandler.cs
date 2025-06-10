using CsvImporter.Data.Models;

namespace CsvImporter
{
    /// <summary>
    /// Handles saving vehicles to the database.
    /// </summary>
    public class DbHandler : IDbHandler
    {
        //saves a list of vehicles to the database
        public bool SaveVehicles(List<Vehicle> vehicles, VEHICLESContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
            }

            foreach (var vehicle in vehicles)
            {
                SaveVehicle(vehicle, context);
            }

            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }
        /// <summary>
        /// saves a single vehicle to the database.
        /// </summary>
        /// <param name="vehicle">the vehicle</param>
        /// <param name="context">the db context</param>
        /// <returns></returns>
        private void SaveVehicle(Vehicle vehicle, VEHICLESContext context)
        {
            context.Vehicles.Add(vehicle);
        }
    }
}
