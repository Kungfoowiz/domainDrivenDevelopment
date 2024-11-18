using Microsoft.Extensions.DependencyInjection;
using System;

using ExampleDDD.Component;
using ExampleDDD.Service;

namespace ExampleDDD
{
  
    class Example
    {
      
        static void Main(string[] args)
        {
            // Set up the Dependency Injection (DI) container with the new constructor parameter.
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGreetSvc>(provider => new GreetSvc("Hi"))
                .AddTransient<GreetHndlr>()
                .BuildServiceProvider();

            // Resolve the service.
            var greetHndlr = serviceProvider.GetService<GreetHndlr>();

            // Use the service by calling the method.
            greetHndlr.GreetUser("Cortana");
        }
      
    }
  
}
