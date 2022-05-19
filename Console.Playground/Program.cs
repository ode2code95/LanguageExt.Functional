using System.Collections.Generic;
using System.Threading.Tasks;
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
            TestMapAsync().Wait();

            WriteLine("Press enter to quit...");
            ReadLine();
        }

        private static async Task TestMapAsync()
        {
            var a = await Some(3).MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done <Unit>!");
                return unit;
            });
            
            var a_n = await Option<Unit>.None.MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("None Done <Unit>!");
                return unit;
            });

            var b = await Some(3).MapAsync<int, Option<Unit>>(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done Option<Unit>!");
                return unit;
            });
            
            var b_n = await Option<int>.None.MapAsync<int, Option<Unit>>(async _ => {
                await Task.Delay(500);
                WriteLine("None Done Option<Unit>!");
                return unit;
            });

            var c = await Some(3).MapAsync(async val => {
                await Task.Delay(500);
                WriteLine("Some Done <bool>!");
                return val < 5;
            });
            
            var c_n = await Option<int>.None.MapAsync(async val => {
                await Task.Delay(500);
                WriteLine("None Done <bool>!");
                return val < 5;
            });

            var d = await Some(3).MapAsync<int, Option<bool>>(async val => {
                await Task.Delay(500);
                WriteLine("Some Done Option<bool>!");
                return val < 5;
            });

            var d_n = await Option<int>.None.MapAsync<int, Option<bool>>(async val => {
                await Task.Delay(500);
                WriteLine("None Done Option<bool>!");
                return val < 5;
            });

            var e = await Some(MyClass.New("")).MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done <MyClass>!");
                return MyClass.New("Stanley");
            });

            var e_n = await Option<MyClass>.None.MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("None Done <MyClass>!");
                return MyClass.New("Stanley");
            });

            var f = await Some(MyClass.New("")).MapAsync<MyClass, Option<MyClass>>(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done Option<MyClass>!");
                return MyClass.New("Stanley");
            });
            
            var f_n = await Option<MyClass>.None.MapAsync<MyClass, Option<MyClass>>(async _ => {
                await Task.Delay(500);
                WriteLine("None Done Option<MyClass>!");
                return MyClass.New("Stanley");
            });
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