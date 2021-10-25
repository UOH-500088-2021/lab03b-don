using System;
using System.IO;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "police_101_call_data.csv";

            var dataReader = new DataReader();
            dataReader.FileName = fileName;
            dataReader.ReadData();

            Console.WriteLine(String.Format("Average total calls: {0}", dataReader.AverageTotalCalls));
            Console.WriteLine(String.Format("Number of rows: {0}", dataReader.NumberOfForces));

            Console.WriteLine("Press enter key to exit");
            Console.ReadLine();
        }
    }

    public class DataReader
    {
        public string FileName { get; set; }

        public int AverageTotalCalls { get; set; }
        public int NumberOfForces { get; set; }
        

        public void ReadData()
        {
            var totalCallsColumn = 2;
            using (StreamReader reader = new StreamReader(FileName))
            {
                var totalCalls = 0;
                var line = reader.ReadLine(); // Read the header line, which doesn't contain data
                while (!reader.EndOfStream)
                {
                    NumberOfForces++;
                    line = reader.ReadLine();
                    var columns = line.Split(",");  // What if there's a comma inside a data column?
                    try
                    {
                        totalCalls += int.Parse(columns[1]);  // What if the data doesn't parse properly?
                    }
                    catch
                    {
                        continue;
                    }
                    PrintEachForceCalls(columns);
                }
                AverageTotalCalls = totalCalls / NumberOfForces;
            }
        }

        

        public void PrintEachForceCalls(string[] data)
        {
            // 12 columns per month
            int totalCalls = 0;
            for(int i = 1; i < 12; i++)
            {
                try
                {
                    totalCalls = +int.Parse(data[i]);
                }
                catch
                {

                }
                
            }
            Console.WriteLine("Force: " + data[0]);
            Console.WriteLine("Total calls: " + totalCalls);
            Console.WriteLine();
        }
    }
        
}
