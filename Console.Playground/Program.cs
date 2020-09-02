using System.Collections.Generic;
using LangExt.Extensions;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Console.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string> {null, "", "Hello World"};
            
            foreach (string t in test)
            {
                System.Console.WriteLine(t.EmptyAsNone());
            }
            
            test.Map(x => x.Apply(Optional));
            
            foreach (string t in test)
            {
                System.Console.WriteLine(t.EmptyAsNone());
            }

            System.Console.WriteLine("Press enter to quit...");
            System.Console.ReadLine();
        }
    }
}