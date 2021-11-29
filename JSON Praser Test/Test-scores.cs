using System;
using Xunit;
using JSON_Parser;
using JSON_Parser.DTOs;
using System.Collections.Generic;

namespace JSON_Praser_Test
{
    public class TestScores
    {
        [Fact]
        public void NonnumericScore()
        {
            //Compile time error, invalid
            Assert.True(true);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(999)]
        [InlineData(-999)]
        [InlineData(0)]
        public void ValidScore(float score)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = "1", ip = "127.0.0.1", score = score });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act + Assert
            foreach(var x in retVal.Item2)
            {
                Assert.Equal(score, x.GetType().GetProperty("SumScore")?.GetValue(x));
            }
        }

        [Theory]
        [InlineData(2.0,2.0,4.0)]
        [InlineData(-1.0, 1.0, 0.0)]
        [InlineData(-1.0, -1.0, -2.0)]
        [InlineData(-0.0, 0.0, 0.0)]
        public void FloatScores(float first, float second, float expectedResult)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = "1", ip = "127.0.0.1", score = first });
            incomingDto.Add(new IncomingDTO { id = "2", ip = "127.0.0.1", score = second });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int total = 0;
            foreach (var x in retVal.Item2)
            {
                total += Convert.ToInt32(x.GetType().GetProperty("SumScore")?.GetValue(x));
            }
            //Assert
            Assert.Equal(expectedResult, total);
        }
    }
}
