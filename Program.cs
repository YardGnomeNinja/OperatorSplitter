using System;
using System.Linq;
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
            var result = "";
            var mathOperators = new string[] { "+", "-", "*", "/" };
            var escapedMathOperators = new string[] { "\\+", "\\-", "\\*", "/" };
            var equalityOperators = new string[] { "==", ">=", "<=", "!=" };

            var regularExpressionPattern = "\\s?([\\w0-9]+)\\s?(" + String.Join('|', escapedMathOperators) + "|" + String.Join('|', equalityOperators) + ")?";
            var matches = Regex.Matches(statement, regularExpressionPattern);

            foreach(Match match in matches)
            {
                //result = match.Value;
                for (var i = 1; i <= match.Groups.Count - 1; i++)
                {
                    var resultEndsWithMathOperator = false;

                    foreach (var mathOperator in mathOperators) {
                        resultEndsWithMathOperator = result.EndsWith(mathOperator);

                        if (resultEndsWithMathOperator)
                            break;
                    }

                    // If the match is not a math operator, result has a value, and the last character of result is not a math operator then add a new line
                    if (!mathOperators.Contains(match.Groups[i].Value) && result != "" && !resultEndsWithMathOperator)
                        result += "\r\n";

                    result += match.Groups[i].Value;
                }
            }

            return result;
        }
    }
}
