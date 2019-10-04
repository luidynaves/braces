using System;
using System.Collections.Generic;

namespace test2
{
    class Program
    {
        public static List<string> GetBraces(string[] values)
        {
            var leftBraces = new HashSet<char>() { '(', '[', '{' };
            var rightBraces = new HashSet<char>() { ')', ']', '}' };            

            var fromTo = new Dictionary<char, char>();
            fromTo.Add('{', '}');
            fromTo.Add('[', ']');
            fromTo.Add('(', ')');             

            var results = new List<string>();

            for (int i = 0; i < values.Length; i++)
            {
                var currentBraces = values[i];
                var stackBraces = new Stack<char>();
                var aligned = "NO";

                for (int y = 0; y < currentBraces.Length; y++)
                {
                    var brace = currentBraces[y];
                    
                    if (!leftBraces.Contains(brace) && !rightBraces.Contains(brace))
                        continue;

                    if (stackBraces.Count == 0 && rightBraces.Contains(brace))
                        break;                    

                    if (leftBraces.Contains(brace))
                    {
                        stackBraces.Push(brace);
                        continue;                        
                    }

                    var popedBrace = stackBraces.Pop();

                    if (fromTo[popedBrace] != brace)
                        break;
                }

                if (stackBraces.Count == 0)
                    results.Add("YES");
                else
                    results.Add(aligned);
            }

            return results;
        }
        
        static void Main(string[] args)
        {
            string[] values = { "{}[]()", "{[}]}" };
            var results = GetBraces(values);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
