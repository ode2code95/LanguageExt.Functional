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

        /// <summary>
        /// This function does not throw anymore.
        /// </summary>
        private static async Task TestMapAsync()
        {
            T GetNone<T>(T value)
            {
                WriteLine($"Got NONE! Getting default of type {typeof(T)}!");
                return value;
            }

            Option<T> BoxNone<T>(T value)
            {
                WriteLine($"Got NONE! Boxing default of type {typeof(T)} . . .");
                return value;
            }

            Unit getUnit() => GetNone(unit);
            Option<Unit> boxUnit() => BoxNone(unit);
            bool getBool() => GetNone(false);
            Option<bool> boxBool() => BoxNone(false);
            MyClass getRefTypeInstance() => GetNone(MyClass.New("[NONE]"));
            Option<MyClass> boxRefTypeInstance() => BoxNone(MyClass.New("[NONE]"));

            var a = await Some(3).MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done <Unit>!");
                return unit;
            }).IfNone(getUnit);
            
            var a_n = await Option<Unit>.None.MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("None Done <Unit>!");
                return unit;
            }).IfNone(getUnit);

            var b = await Some(3).MapAsync<int, Option<Unit>>(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done Option<Unit>!");
                return unit;
            }).IfNone(boxUnit);
            
            var b_n = await Option<int>.None.MapAsync<int, Option<Unit>>(async _ => {
                await Task.Delay(500);
                WriteLine("None Done Option<Unit>!");
                return unit;
            }).IfNone(boxUnit);

            var c = await Some(3).MapAsync(async val => {
                await Task.Delay(500);
                WriteLine("Some Done <bool>!");
                return val < 5;
            }).IfNone(getBool);
            
            var c_n = await Option<int>.None.MapAsync(async val => {
                await Task.Delay(500);
                WriteLine("None Done <bool>!");
                return val < 5;
            }).IfNone(getBool);

            var d = await Some(3).MapAsync<int, Option<bool>>(async val => {
                await Task.Delay(500);
                WriteLine("Some Done Option<bool>!");
                return val < 5;
            }).IfNone(boxBool);

            var d_n = await Option<int>.None.MapAsync<int, Option<bool>>(async val => {
                await Task.Delay(500);
                WriteLine("None Done Option<bool>!");
                return val < 5;
            }).IfNone(boxBool);

            var e = await Some(MyClass.New("")).MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done <MyClass>!");
                return MyClass.New("Stanley");
            }).IfNone(getRefTypeInstance);

            var e_n = await Option<MyClass>.None.MapAsync(async _ => {
                await Task.Delay(500);
                WriteLine("None Done <MyClass>!");
                return MyClass.New("Stanley");
            }).IfNone(getRefTypeInstance);

            var f = await Some(MyClass.New("")).MapAsync<MyClass, Option<MyClass>>(async _ => {
                await Task.Delay(500);
                WriteLine("Some Done Option<MyClass>!");
                return MyClass.New("Stanley");
            }).IfNone(boxRefTypeInstance);
            
            var f_n = await Option<MyClass>.None.MapAsync<MyClass, Option<MyClass>>(async _ => {
                await Task.Delay(500);
                WriteLine("None Done Option<MyClass>!");
                return MyClass.New("Stanley");
            }).IfNone(boxRefTypeInstance);
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