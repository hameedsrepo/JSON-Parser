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
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string pathToFile = System.IO.Path.Combine(baseDir, @"..\..\..\Test Files\test.json");
            pathToFile = System.IO.Path.GetFullPath(pathToFile);
            pathToFile = "\"" + pathToFile + "\""; //required for parameter of Main with spaces, otherwise will split up

            string pathToApp = System.IO.Path.Combine(baseDir, @"..\..\..\..\JSON Parser\bin\Debug\net5.0\JSON Parser.exe");
            pathToApp = System.IO.Path.GetFullPath(pathToApp);

            Console.WriteLine($"Path to File: {pathToFile} \nPath To App: {pathToApp}");//this works!
            ProcessStartInfo startInfo = new ProcessStartInfo(pathToApp);
            //1. run JSON Parser with parameters we want (our text file is fine)
            //https://stackoverflow.com/questions/186822/capturing-console-output-from-a-net-application-c

            startInfo.Arguments = pathToFile;
            Process.Start(startInfo);

            //2. output the console into something readable but this applicaiton
            //3. parse data and verify the actual results are what we expect
            //4. optional - generate our own files programmatically to run
            Console.WriteLine("Ending Application.");
        }
    }
}
