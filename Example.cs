

// All models/domains follow this pattern.
// Pros: Reusable, consistent + testable.
// Cons: Interface methods public, multiple inheritance to single class, must be rigorously followed.

// The vision for DDD in MVC/WebAPI:

// Controllers
// -----------
// Dependency injection.
// Integration tested.

// Views
// -----
// End-to-End tested with Cucumber, Protractor, Selenium.
// Unit tested with Jasmine.

// Models
// ------
// Dependency injection.
// Unit tested with NUnit/Rhino Mocks.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MySpace
{

    // The interface forms the contract or high level definition of the model.
    // It differs from an abstract class because here we are purely expressing a high level definition.
    // There is supposed to be no code in an interface.
    // It should be kept as a separate file with a name prefixed by 'I', for example: IMyInterface.cs
    // Any class (model/domain) usages then inherit this interface.
    public interface IMyInterface
    {
        log ILogfile;

        bool isOk;

        string getName();
    }
    
    // The actual model/domain can be a class (MyClass.cs)
    // Interface (IMyInterface) defines what is expected of the model.
    // It serves many purposes, you can have multiple models (domains),
    // 1. Multiple models but can have different implementations.
    // 2. An expected contract is established for all models, so instances can be called in the same way.
    // 3. Interfaces can be mocked for testing purposes (Rhino Mocks for example).
    public class MyClass : IMyInterface
    {

        // Variables used throughout the model are always delcared here.
        // Only a result variable is usually local to any function, otherwise try keep them all here.

        private log ILog;
        
        private bool isOk;

        public string getName();


        // On the constructor: log is depedency injected (DI).
        // This is typically handled internally (Dotnet Core) or with StructureMap (ASP.NET MVC/WebAPI).
        public MyClass(ILog log)
        {
            this.log = log
            this.isOk = true;
        }

        public string getName()
        {
          // Local var and single return path.
          string result;

          // Single return path is easier to check logic and we always know where to find its declaration.

          // Logic here, make sure to use transaction.
          // Get the name here.
          result = "something";

          return result;
        }

    }
}
