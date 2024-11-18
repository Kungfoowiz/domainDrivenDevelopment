using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

using ExampleDDD.Service;

namespace ExampleDDD.Tests
{

    [TestFixture]
    public class GreetSvcTest
    {
      
        private ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            // Inject a new service it into the service provider container for tests to use it.
            var serviceCollection = new ServiceCollection();
          
            serviceCollection.AddSingleton<IGreetSvc, GreetSvc>(
              provider => new GreetSvc("Hi")
            );
          
            this.serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [TearDown]
        public void Teardown()
        {
            // Dispose the service provider after the test finishes.
            this.serviceProvider.Dispose();
        }

      
        [Test]
        public void Greet_ShouldReturnGreetingMessage()
        {
            // Arrange.
            string expectedGreeting = "Hi, Alice!";
            var greetingService = this.serviceProvider.GetService<IGreetSvc>();

            // Act.
            string actualGreeting = greetingService.Greet("Alice");

            // Assert.
            Assert.AreEqual(expectedGreeting, actualGreeting);
        }

      
        [Test]
        public void Greet_ShouldHandleNullName()
        {
            // Arrange.
            var greetingService = this.serviceProvider.GetService<IGreetSvc>();

            // Act.
            TestDelegate act = () => greetingService.Greet(null);

            // Assert.
            Assert.Throws<ArgumentNullException>(act);
        }

      
        [Test]
        public void Greet_ShouldHandleEmptyName()
        {
            // Arrange.
            var greetingService = this.serviceProvider.GetService<IGreetSvc>();

            // Act.
            string actualGreeting = greetingService.Greet(string.Empty);

            // Assert.
            string expectedGreeting = "Hi, !";
            Assert.AreEqual(expectedGreeting, actualGreeting);
        }
      
    }
  
}

