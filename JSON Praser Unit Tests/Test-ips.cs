using JSON_Parser;
using JSON_Parser.DTOs;
using System;
using System.Collections.Generic;
using Xunit;

namespace JSON_Praser_Test
{
    /// <summary>
    /// Test various IPs:
    /// IPV4
    /// IPV6
    /// </summary>
    public class TestIps
    {
        [Fact]
        public void InvalidFormat()
        {
            //Arrange
            //Application does not care for formatting of IP addresses
            //Act
            //Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData("127.0.0.1", "2001:0db8:85a3:0000:0000:8a2e:0370:7334", 2)]
        public void ValidFormat(string ip1, string ip2, int count)
        {
            //Arrange
            List<IncomingDTO> incomingDto = new List<IncomingDTO>();
            incomingDto.Add(new IncomingDTO { id = "1", ip = ip1, score = 20 });
            incomingDto.Add(new IncomingDTO { id = "2", ip = ip2, score = 20 });
            Tuple<IEnumerable<object>, IEnumerable<object>> retVal = Program.Calculations(incomingDto);
            //Act
            int ipCount = 0;
            List<string> ip = new List<string>();
            foreach (var x in retVal.Item1)
            {
                ipCount += Convert.ToInt32(x.GetType().GetProperty("ipCount")?.GetValue(x));
                Object tmp = x.GetType().GetProperty("Key")?.GetValue(x);
                ip.Add(tmp.GetType().GetProperty("ip")?.GetValue(tmp).ToString());
            }
            //Assert
            Assert.Equal(count, ipCount);
            
        }
    }
}
