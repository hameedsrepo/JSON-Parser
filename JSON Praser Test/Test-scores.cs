using System;
using Xunit;

namespace JSON_Praser_Test
{
    public class TestScores
    {
        [Fact]
        public void NonnumericScore()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void ValidScore()
        {
            //Arrange
            //Act
            //Assert
        }

        [Theory]
        [InlineData(2.0,2.0,4.0)]
        public void FloatScore(float first, float second, float expectedResult)
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(first + second, expectedResult);
        }
    }
}
