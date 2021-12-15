using System;
using System.Diagnostics;

namespace BlackBoxTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string pathToFile = System.IO.Path.Combine(baseDir, @"..\..\..\Test Files\test.json");
            pathToFile = System.IO.Path.GetFullPath(pathToFile);
            pathToFile = "\"" + pathToFile + "\""; //required for parameter of Main with spaces, otherwise will split up

            string pathToApp = System.IO.Path.Combine(baseDir, @"..\..\..\..\JSON Parser\bin\Debug\net5.0\JSON Parser.exe");
            pathToApp = System.IO.Path.GetFullPath(pathToApp);

            validation(pathToFile, pathToApp, "test\r\n1.2.3.4:2\r\n1.2.3.5:1\r\n34\r\ntest2\r\n1.2.3.4:5\r\n45");

            pathToFile = pathToFile.Replace("test.json", "test1.json");
            validation(pathToFile, pathToApp, "test\r\n1.2.3.4:1\r\n12");

            //optional - generate our own files programmatically to run
            /* I have demonstrated the ability that 
             * I can do this and time is precious 
             * so hopefully this will suffice. */

            Console.WriteLine("Ending Application.");
        }

        public static void validation(string pathToFile, string pathToApp, string expectedValues)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(pathToApp);
            startInfo.RedirectStandardOutput = true;

            startInfo.Arguments = pathToFile;
            Process process= Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd();

            string[] tmpVals = output.Split("The output is:");

            string outVals;
            if (tmpVals.Length > 1)
            {

                outVals = tmpVals[1].Trim();
            }
            else
            {
                outVals = "error!";
            }

            Console.WriteLine(String.Compare(outVals, expectedValues) == 0 ? "The output for test1.json is correct." : "The output for test1.json is incorrect.");

        }
    }
}
