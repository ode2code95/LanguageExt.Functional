using LanguageExt.Extensions;

namespace Console.Playground
{
    public interface IHelloWorld
    {
        string HelloWorldMsg();
    }
    
    public class HelloIllinois : IHelloWorld
    {
        string IHelloWorld.HelloWorldMsg() => "Hello, Illinois!";
    }

    public class SwitchBoard
    {
        // won't compile
        // public string CallIllinois() => new HelloIllinois().HelloWorldMsg();
        
        // fixed
        public string CallIllinoisFixed() => new HelloIllinois().As<IHelloWorld>().HelloWorldMsg();
    }
}