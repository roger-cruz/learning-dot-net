using System;
using System.Diagnostics;

// Copyright Roger Cruz (roger_r_cruz@@yahoo.com)
namespace ListPerformanceCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inspired by https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.performancecountercategory.getcategories?redirectedfrom=MSDN&view=netframework-4.7.2#overloads
            PerformanceCounterCategory[] categories;
            categories = PerformanceCounterCategory.GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine("Press key to exit");
            Console.ReadLine();

        }
    }
}
