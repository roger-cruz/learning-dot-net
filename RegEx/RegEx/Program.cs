using System;
using System.Text.RegularExpressions;


namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^dog.*";
            string input1 = "dog runs around\ndog2 runs around too.";

            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match match = rx.Match(input1);
            while (match.Success)
            {
                Console.WriteLine("'{0}' found at position {1}.",
                                   match.Value, match.Index);
                match = match.NextMatch();
            }
        }
    }
}
