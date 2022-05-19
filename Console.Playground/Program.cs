using System.Collections.Generic;
using LangExt.Extensions;
using LanguageExt;
using static LanguageExt.Prelude;
using static System.Console;

namespace Console.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestEmptyAsNone();

            WriteLine("Press enter to quit...");
            ReadLine();
        }

        private static void TestEmptyAsNone()
        {
            List<string> test = new List<string> { null, "", "Hello World" };

            foreach (string t in test)
            {
                WriteLine(t.EmptyAsNone());
            }

            test.Map(x => x.Apply(Optional));

            foreach (string t in test)
            {
                WriteLine(t.EmptyAsNone());
            }

            WriteLine($"\n{new SwitchBoard().CallIllinoisFixed()}\n");
        }
    }
}