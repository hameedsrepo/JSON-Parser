using JSON_Parser;
using JSON_Parser.DTOs;
using System;
using System.Collections.Generic;
using Xunit;

namespace JSON_Praser_Test
{
    public class IdTest
    {
        [Fact]
        public void ZeroIds()
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int ipCount = 0;
            foreach (var x in retVal.Item1)
            {
                ipCount += Convert.ToInt32(x.GetType().GetProperty("ipCount")?.GetValue(x));
            }
            //Assert
            Assert.Equal(0, ipCount);
        }

        [Theory]
        [InlineData("id1")]
        public void OneId(string id1)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = id1, ip = "127.0.0.1", score = 20 });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int ipCount = 0;
            foreach (var x in retVal.Item1)
            {
                ipCount += Convert.ToInt32(x.GetType().GetProperty("ipCount")?.GetValue(x));
            }
            //Assert
            Assert.Equal(1, ipCount);
        }

        [Theory]
        [InlineData("id1", "id1")]
        public void TwoOfTheSameIds(string id1, string id2)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = id1, ip = "127.0.0.1", score = 20 });
            incomingDto.Add(new IncomingDTO { id = id2, ip = "127.0.0.1", score = 20 });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int ipCount = 0;
            foreach (var x in retVal.Item1)
            {
                ipCount += Convert.ToInt32(x.GetType().GetProperty("ipCount")?.GetValue(x));
            }
            //Assert
            Assert.Equal(1, ipCount);
        }

        [Theory]
        [InlineData("id1", "id2")]
        public void TwoDifferentIds(string id1, string id2)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = id1, ip = "127.0.0.1", score = 20 });
            incomingDto.Add(new IncomingDTO { id = id2, ip = "127.0.0.1", score = 20 });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int ipCount = 0;
            foreach (var x in retVal.Item1)
            {
                ipCount += Convert.ToInt32(x.GetType().GetProperty("ipCount")?.GetValue(x));
            }
            //Assert
            Assert.Equal(2, ipCount);
        }
    }
}
