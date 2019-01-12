using System;
using System.Diagnostics;

// Copyright Roger Cruz (roger_r_cruz@@yahoo.com)

namespace ListWCFServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Learned this trick from: https://stackoverflow.com/questions/1091406/how-to-get-list-of-all-wcf-services-running-on-a-machine
            string[] categories = { "ServiceModelService 3.0.0.0", "ServiceModelService 4.0.0.0",
            "ServiceModelEndpoint 3.0.0.0", "ServiceModelEndpoint 4.0.0.0"};

            foreach (var categoryName in categories)
            {
                var category = new PerformanceCounterCategory(categoryName);
                Console.WriteLine("Category name: {0}", categoryName);
                PrintInstances(category);
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("Press key to exit");
            Console.ReadLine();
        }

        static void PrintInstances(PerformanceCounterCategory category)
        {
            string[] instances;
            try
            {
                instances = category.GetInstanceNames();
            }
            catch
            {
                Console.WriteLine("No instances found in this category.");
                return;
            }

            foreach (var instance in instances)
            {
                Console.WriteLine(instance);
            }
        }
    }
}
