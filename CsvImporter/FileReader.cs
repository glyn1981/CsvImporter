using CsvImporter.Data.Models;
namespace CsvImporter
{

    /// <summary>
    /// Handles reading a file and converting its contents into a list of Vehicle objects.
    /// </summary>
    public class FileReader : IFileReader
    {

        /// <summary>
        /// Reads a file from the specified file name and returns a list of vechiles.
        /// Handles just the part that reads the file into a list of string.
        /// </summary>
        /// <param name="FileName"></param>
        public List<Vehicle> ReadFile(string FileName)
        {

            var vehicles = new List<Vehicle>();
            int rowNo = 1;
            List<string> stringItems = new List<string>();

            foreach (var line in File.ReadLines(FileName))
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                //we dont want to convert the header
                //its not a vehicle.
                if (rowNo != 1)
                {
                    stringItems.Add(line.Trim());
                }
                rowNo +=1;
            }

            return ConvertLinesToVehicles(stringItems);
        }

        /// <summary>
        /// Converts a list of strings (each representing a line in the CSV file) into a list of Vehicle objects.
        /// </summary>
        /// <param name="stringItems"></param>
        /// <returns></returns>
        public List<Vehicle> ConvertLinesToVehicles(List<String> stringItems)
        {
            var vehicles = new List<Vehicle>();

            foreach (string line in stringItems)
            {
                // Split by comma
                var parts = line.Split(',');

                // Ensure there are at least 4 columns
                if (parts.Length < 4)
                    continue;

                var vehicle = new Vehicle
                {
                    Make = parts[0].Trim(),
                    Model = parts[1].Trim(),
                    Color = parts[2].Trim(),
                    Reg = parts[3].Trim()
                };

                vehicles.Add(vehicle);

            }
            return vehicles;

        }



    }
}
