using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Parser.DTOs
{
    /// <summary>
    /// A DTO that represents the critical properties of an incoming JSON object after it's deserialized
    /// </summary>
    public class IncomingDTO
    {
        public string id { get; set; }
        public float score { get; set; }
        public string ip { get; set; }
    }
}
