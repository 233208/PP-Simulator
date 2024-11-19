using Simulator.Maps;

namespace Simulator.Tests
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            // Arrange
            int size = 10;
            // Act
            var map = new SmallSquareMap(size);
            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void SmallSquareMap_ValidSize_ShouldCreateMap(int size)
        {
            // Arrange & Act
            var map = new SmallSquareMap(size);

            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        public void SmallSquareMap_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(10, 0, 0, true)]
        [InlineData(6, 5, 5, true)]
        [InlineData(9, -1, 0, false)]
        [InlineData(6, 0, -1, false)]
        [InlineData(10, 10, 11, false)]
        [InlineData(20, 20, 20, false)]
        public void Exist_ShouldReturnCorrectValue(int size, int x, int y, bool expected)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);

            // Act
            var result = map.Exist(point);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(5, 5, Direction.Right, 6, 5)]
        [InlineData(9, 9, Direction.Down, 9, 8)]
        [InlineData(0, 10, Direction.Left, 0, 10)]
        public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallSquareMap(10);
            var point = new Point(x, y);

            // Act
            var result = map.Next(point, direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }
}