using Newtonsoft.Json;
using System;
using System.IO;
using JSON_Parser.DTOs;
using System.Collections.Generic;
using System.Linq;
using JSON_Parser.Validation;

namespace JSON_Parser
{
    /// <summary>
    /// This is a dotnet 5.0 console application that is responsible for:
    ///     - deseriziling a JSON object
    ///     - identifying all unique IDs within the JSON
    ///     - grouping all unique IPs and counting them
    ///     - summing the scores within a set of unique IDs
    ///     - displaying the resulsts on the console
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation;
            do
            {
                Console.WriteLine("Welcome to the JSON Parser.  My job is to group unique IDs, give counts of IPs with the same unique ID and sum the entire score by ID.");
                Console.WriteLine("Please specify a location to your JSON file to be analyzed:");

                fileLocation = Console.ReadLine();

                try
                {
                    List<IncomingDTO> incomingDTOs = loadJson(fileLocation);

                    var resultSet = incomingDTOs
                        .GroupBy(x => x.id);

                    //TO DO: figure out correct LINQ statement
                    //from i in incomingDTOs
                    //group i by i.id into g
                    //select new ResultDTO
                    //{
                    //    id = g.Key,
                    //    scoreSum = g.Sum(x => x.score), 
                    //    count = 0, 
                    //    ip = ""
                    //};
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}.\n{e.StackTrace}");
                }
            } while (!string.IsNullOrEmpty(fileLocation));
        }

        static List<IncomingDTO> loadJson(string jsonPath)
        {
            List<IncomingDTO> retVal = new List<IncomingDTO>();
            try
            {
                using (StreamReader reader = new StreamReader(jsonPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string jsonLine = reader.ReadLine(); //assuming 1 entry per line
                        //verify jsonLine is a valid JSON
                        if(!String.IsNullOrEmpty(jsonLine) && JsonValidator.isValidJson(jsonLine))
                            retVal.Add(JsonConvert.DeserializeObject<IncomingDTO>(jsonLine));
                    }
                    return retVal;
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
