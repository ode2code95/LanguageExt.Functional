namespace Console.Playground
{
    class MyClass
    {
        public string Name { get; private set; }
        public static MyClass New(string n) => new() { Name = n };
    }
}