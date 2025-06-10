namespace CsvImporter.Test
{
    /// <summary>
    /// Tests for validating user input in the CSV importer application.
    /// </summary>
    public class InputValidationTests
    {
        /// <summary>
        /// Tests that a null input returns false.
        /// </summary>
        [Fact]
        public void ValidateNullInputTest_ShouldReturnFalse()
        {

            InputValidator inputValidator = new InputValidator(new UIHandler());
            bool result =inputValidator.ValidateInput(null);
            Assert.False(result);

        }

        /// <summary>
        /// Tests that a file which doesnt exist returns false.
        /// </summary>
        [Fact]
        public void ValidateNonExistentInputTest_ShouldReturnFalse()
        {

            InputValidator inputValidator = new InputValidator(new UIHandler());
            bool result = inputValidator.ValidateInput("C:\\DIRECTORY_THAT_DOESNT_EXIST\\FILE_THAT_DOESNT_EXIST.CSV");
            Assert.False(result);

        }

        /// <summary>
        /// Tests that a file that should exist returns true.
        /// NOTE: This might not work in all environments, as it depends on the file system.
        /// Possibly a problem in CI/CD pipelines or different OS environments.
        /// </summary>
        [Fact]
        public void ValidateFileExists_ShouldReturnTrue()
        {

            InputValidator inputValidator = new InputValidator(new UIHandler());
            bool result = inputValidator.ValidateInput("C:\\Windows\\notepad.exe");
            Assert.True(result);

        }
    }
}