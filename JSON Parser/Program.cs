using Newtonsoft.Json;
using System;
using System.IO;
using JSON_Parser.DTOs;

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
                    IncomingDTO incomingDTO = loadJson(fileLocation);
                    Console.WriteLine($"id: {incomingDTO.id}  score: {incomingDTO.score}  ip: {incomingDTO.ip}");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.Message}.\n {e.StackTrace}");
                }
            } while (!string.IsNullOrEmpty(fileLocation));
        }

        static IncomingDTO loadJson(string jsonPath)
        {
            using (StreamReader reader = new StreamReader(jsonPath))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IncomingDTO>(json);
            }
        }
    }
}
