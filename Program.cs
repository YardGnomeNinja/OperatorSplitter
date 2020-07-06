using System;
using System.Text.RegularExpressions;

namespace OperatorSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a comparison statement...");
            var statement = Console.ReadLine();
            var splitStatement = SplitStatement(statement);

            Console.WriteLine();
            Console.WriteLine("The statement consists of the following:");
            Console.WriteLine(splitStatement);
        }

        static string SplitStatement(string statement)
        {
            var matches = Regex.Matches(statement, "\\s?([\\w0-9]+)\\s?(==|>=|<=)?");
            var result = "";

            foreach(Match match in matches)
            {
                //result = match.Value;
                for (var i = 1; i <= match.Groups.Count - 1; i++)
                {
                    if (result != "")
                        result += "\r\n";

                    result += match.Groups[i].Value;
                }
            }

            return result;
        }
    }
}
