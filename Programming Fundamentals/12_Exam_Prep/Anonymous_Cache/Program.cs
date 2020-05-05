using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Anonymous_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> dataSet = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {
                if (input.Contains("->"))
                {
                    string[] dataInfo = input.Split(new char[] { ' ', '-', '>', '|' },
                        StringSplitOptions.RemoveEmptyEntries);
                    string dataKey = dataInfo[0];
                    long dataSize = long.Parse(dataInfo[1]);
                    string splittedDataSet = dataInfo[2];                  

                    if (!dataSet.ContainsKey(splittedDataSet))
                    {
                        if (!cache.ContainsKey(splittedDataSet))
                        {
                            cache[splittedDataSet] = new Dictionary<string, long>();
                        }
                        cache[splittedDataSet].Add(dataKey, dataSize);
                    }
                    else
                    {
                        if (!dataSet[splittedDataSet].ContainsKey(dataKey))
                        {
                            dataSet[splittedDataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            dataSet[splittedDataSet][dataKey] += dataSize;
                        }

                    }
                }
                else
                {
                    dataSet.Add(input, new Dictionary<string, long>());
                    if (cache.ContainsKey(input))
                    {
                        foreach (var kvp in cache[input])
                        {
                            dataSet[input].Add(kvp.Key, kvp.Value);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            try
            {
                var result = dataSet.OrderByDescending(x => x.Value.Values.Sum()).First();
                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Values.Sum()}");
                foreach (var dataKey in result.Value)
                {
                    Console.WriteLine($"$.{dataKey.Key}");
                }
            }
            catch
            {
                Console.WriteLine("");
            }
        }
    }
}
