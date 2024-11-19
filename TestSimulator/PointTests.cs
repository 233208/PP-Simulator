namespace Simulator.Tests
{
    public class PointTests
    {

        [Theory]
        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(5, 5, Direction.Right, 6, 5)]
        [InlineData(10, 10, Direction.Down, 10, 9)]
        [InlineData(0, 10, Direction.Left, -1, 10)]
        public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.Next(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(5, 5, Direction.Right, 6, 4)]
        [InlineData(10, 10, Direction.Down, 9, 9)]
        [InlineData(0, 10, Direction.Left, -1, 11)]
        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
        [Theory]
        [InlineData(1, 1, "(1, 1)")]
        [InlineData(420, 777, "(420, 777)")]
        [InlineData(-1, -1, "(-1, -1)")]

        public void ToString_ShouldReturnCorrectFormat(int x, int y, string expected)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.ToString();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}