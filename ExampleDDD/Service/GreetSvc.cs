using System;

namespace ExampleDDD.Service
{

    // This service will take an input as a greeting prefix in the constructor.
    
    // It has a public method Greet.
    // Greet method returns the greeting prefix and your inputted name as a string.

    public class GreetSvc : IGreetSvc
    {
        private readonly string greeting;

        public GreetSvc(string greeting = "Hi")
        {
            this.greeting = greeting;
        }

        public string Greet(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return $"{this.greeting}, {name}!";
        }
    }
}
