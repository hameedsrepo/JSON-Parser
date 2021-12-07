using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlackBoxTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //0. Setup
            string pathToApp = @"C:\Users\ps3se\source\repos\JSON Parser\JSON Parser\bin\Debug\net5.0\JSON Parser.exe"; //change so we can use relative paths
            ProcessStartInfo startInfo = new ProcessStartInfo(pathToApp);
            //1. run JSON Parser with parameters we want (our text file is fine)
            //https://stackoverflow.com/questions/186822/capturing-console-output-from-a-net-application-c
            
            startInfo.Arguments = @"Z:\test.json"; //change so we can use relative paths
            Process.Start(startInfo);

            //2. output the console into something readable but this applicaiton
            //3. parse data and verify the actual results are what we expect
            //4. optional - generate our own files programmatically to run
            Console.WriteLine("Ending Application.");
        }
    }
}
