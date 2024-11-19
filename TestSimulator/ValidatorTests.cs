namespace Simulator.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 0, 10, 5)]
        [InlineData(-5, 0, 10, 0)]
        [InlineData(15, 0, 10, 10)]
        [InlineData(5, 5, 10, 5)]
        [InlineData(5, 0, 5, 5)]
        [InlineData(5, 5, 5, 5)]
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            // Arrange & Act
            var result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("t", 1, 10, '#', "T")]
        [InlineData("test", 1, 10, '#', "Test")]
        [InlineData("to jest bardzo dlugi test      ", 1, 7, '#', "To jest")]
        [InlineData("test", 1, 3, '#', "Tes")]
        [InlineData("t", 5, 10, '#', "T####")]
        [InlineData("  t  ", 4, 6, '#', "T###")]
        [InlineData("  test  ", 1, 10, '#', "Test")]
        [InlineData("  TEST  ", 1, 10, '#', "TEST")]
        [InlineData("", 5, 10, '#', "#####")]
        public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
        {
            // Arrange & Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}