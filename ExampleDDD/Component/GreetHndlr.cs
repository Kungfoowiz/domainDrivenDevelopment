using System;

using ExampleDDD.Services;

namespace ExampleDDD.Component
{

    // Our component uses Dependency Injection (DI) for a service.
    public class GreetHndlr
    {
        private readonly IGreetSvc greetSvc;

        // The service is injected via our constructor.
        public GreetHndlr(IGreetSvc greetSvc)
        {
            this.greetSvc = greetSvc;
        }

        public void GreetUser(string name)
        {
            string greeting = this.greetSvc.Greet(name);
          
            Console.WriteLine(greeting);
        }
    }
}
