using Moq;
using System.Text;

namespace CsvImporter.Test
{
    /// <summary>
    /// Testing the integration of the components in the CsvImporter project.
    /// </summary>
    public class IntegrationTests
    {
        StringBuilder _conOut = null!;
        Mock<TextReader> _conInput = null!;

        /// <summary>
        /// Setup method to init the console output and input for testing.
        /// </summary>
        public IntegrationTests()
        {
            _conOut = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_conOut);
            _conInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_conInput.Object);
        }


        /// <summary>
        /// emulate the console running, and the user entering a valid file path.
        /// </summary>
        [Fact]
        public void TestIntegration_ValidPathProvided_DataSavedToDB()
        {

            // Arrange
            var userResponses = new string[]{"C:\\vehicles.csv"};
            var sequence = SetupUserResponses(userResponses);

            // Act
            Program.Main();

            // Assert
            foreach (var response in userResponses)
            {
                _conInput.Verify(x => x.ReadLine(), Times.Exactly(1));
            }

            Assert.Contains("Welcome to the CSV Importer Application!", _conOut.ToString());
            Assert.Contains("Please follow the prompts to import your CSV file.", _conOut.ToString());
            Assert.Contains("The CSV File has been successfully imported.", _conOut.ToString());
            Assert.Contains("All vehicles saved successfully to SQL Database.", _conOut.ToString());

        }


        /// <summary>
        /// emulate the console running, and the user entering an invalid file path.
        /// had to make the ui work a little differently to allow for integration testing.
        /// could improve this .
        /// </summary>
        [Fact]
        public void TestIntegration_InvalidValidPathProvided_DataNotSavedToDB()
        {

            // arrange
            var userResponses = new string[]{"C:\\this_doesnt_exist.csv"};
            var sequence = SetupUserResponses(userResponses);

            // act
            Program.Main();

            // assert
            foreach (var response in userResponses)
            {
                _conInput.Verify(x => x.ReadLine(), Times.Exactly(1));
            }

            Assert.Contains("Welcome to the CSV Importer Application!", _conOut.ToString());
            Assert.Contains("Please follow the prompts to import your CSV file.", _conOut.ToString());
            Assert.Contains("The file path is invalid. Re-Run the application to try again.", _conOut.ToString());



        }
        /// <summary>
        /// setup user response collection for the console input.
        /// </summary>
        /// <param name="userResponses"></param>
        /// <returns></returns>
        private MockSequence SetupUserResponses(params string[] userResponses)
        {
            var sequence = new MockSequence();
            foreach (var response in userResponses)
            {
                _conInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
            }
            return sequence;
        }
    }
}