using CsvImporter.Data.Models;

namespace CsvImporter.Test
{
    /// <summary>
    /// Tests for the LineReader functionality, which reads lines from a file and converts them into Vehicle objects.
    /// </summary>
    public class LineReaderTests
    {

        /// <summary>
        /// Tests that a single valid line is converted into a single Vehicle object.
        /// </summary>
        [Fact]
        public void ConvertLinesToVehicles_OneValidLine_ReturnsOneVehicle()
        {

            FileReader fileReader = new FileReader();

            List<string> strings = new List<string>
            {
                "1,red,Audi,S3,S3 4ME"
            };

            List<Vehicle> vehicles = new List<Vehicle>() { new Vehicle{ Color = "red", Make = "Audi", Model = "S3", Reg = "S3 4ME" } };
        
            List<Vehicle> output= fileReader.ConvertLinesToVehicles(strings);
            Assert.NotEmpty(strings);
            Assert.Equal(vehicles.Count, output.Count);

        }

        /// <summary>
        /// Tests that two valid lines are converted into two Vehicle objects.
        /// </summary>
        [Fact]
        public void ConvertLinesToVehicles_TwoValidLines_ReturnsTwoVehicles()
        {

            FileReader fileReader = new FileReader();

            List<string> strings = new List<string>
            {
                "1,red,Audi,S3,S3 4ME",
                "2,white,BMW,M5,M5 4ME"
            };

            List<Vehicle> vehicles = new List<Vehicle>() { 
                new Vehicle { Color = "red", Make = "Audi", Model = "S3", Reg = "S3 4ME" },
                new Vehicle { Color = "white", Make = "BMW", Model = "M5", Reg = "M5 4ME" } 
            };


            List<Vehicle> output = fileReader.ConvertLinesToVehicles(strings);
            Assert.NotEmpty(strings);
            Assert.Equal(vehicles.Count, output.Count);

        }

        /// <summary>
        /// Tests that an empty list of strings returns an empty list of vehicles.
        /// </summary>
        [Fact]
        public void ConvertLinesToVehicles_NoValidData_ReturnsNoVehicles()
        {

            FileReader fileReader = new FileReader();

            List<string> strings = new List<string>
            {
                ""
            };

            List<Vehicle> output = fileReader.ConvertLinesToVehicles(strings);
            Assert.NotEmpty(strings);
            Assert.Empty(output);

        }



    }
}