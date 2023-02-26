//This file was created by @stefanandrei7
//Free to use, feel free to add/change what you deem necessary


using LearnCSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

//Learn all C Sharp Keywords: abstract, delegate, virtual, static, const, readonly, internal, sealed, using, break, continue

namespace LearnCSharp
{

    // STATIC Keyword
    //In C#, the static keyword is used to define a member or type that belongs to the class itself,
    //rather than to any specific instance of the class. This means that you can access the member
    //or type without having to create an instance of the class first.

    public class StaticExample
    {
        public static int MyStaticField = 42;

        public static void MyStaticMethod()
        {
            Console.WriteLine("Static Method");
        }

    }

    //You might use the static keyword to define utility methods or properties that don't depend on any specific instance of a class,
    //or to define global settings or state that are shared across all instances of a class.
    //It's worth noting that you can also define a class itself as static, in which case it cannot be instantiated and all of its members and fields must be static.
    //This can be useful in certain cases, such as defining a set of utility methods that don't require any state or dependencies.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //ABSTRACT Keyword
    //In C#, the abstract keyword is used to define an abstract class or an abstract method.
    //An abstract class is a class that cannot be instantiated on its own, but serves as a base class for other classes.
    //An abstract method is a method that does not have an implementation and must be overridden by any derived class.

    public abstract class Shape
    {
        public abstract double GetArea();
    }

    //Abstract classes and methods can be useful when you want to define a base class or method that provides a common interface for derived classes,
    //but does not provide a complete implementation. By defining abstract members, you can force derived classes to provide their own implementations,
    //which can help to improve code consistency and maintainability.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //REF and OUT Keyowrds

    //The ref keyword is used to pass an argument by reference, and the variable being passed must be initialized before it is passed.
    //The out keyword is similar to ref, but the variable being passed does not need to be initialized before it is passed.

    public class RefAndOutExample
    {
        public static void IncrementValue(ref int value)
        {
            value++;
        }

        public static void GetValues(out int x, out int y)
        {
            x = 1;
            y = 2;
        }

    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //SEALED Keyword
    //In C#, the sealed keyword is used to prevent a class or method from being inherited or overridden.
    //When a class is marked as sealed, it cannot be used as a base class for another class.
    //When a method is marked as sealed, it cannot be overridden in a derived class.

    public sealed class SealedClass1
    {
        // Class members here
    }

    //Now no class can inherit MyClass:
    //public class NotSealedClass1 : SealedClass1
    //If you uncomment the above line you will get the error because NotSealedClass1 tries to inherit SealedClass1, that has the sealed keyword

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //In C#, the const and readonly keywords are used to define constants that cannot be changed at runtime.
    //CONST values are evaluated at COMPILE TIME,
    //while READONLY values can be evaluated at RUNTIME.

    public class ConstAndReadonlyExample
    {
        public const int MyConstant1 = 123; //const var declared for compile time

        public readonly int MyConstant2; //value of readonly set in constructor, cannot be changed after it is set

        public ConstAndReadonlyExample(int value)
        {
            MyConstant2 = value;            //readonly var declared in constructor
        }
    }


    // ----------------------------------------------***********************************************************-------------------------------------------------------------------
    //DELEGATE Keyword
    //In C#, the delegate keyword is used to define a delegate, which is a type that represents a method with a specific signature.
    //Delegates are similar to function pointers in C and C++, and they can be used to pass methods as arguments to other methods or to store references to methods in data structures.

    public delegate int DelegateExample(int a, int b);

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------
    //IDISPOSABLE Keyword
    //In C#, the IDisposable interface is used to provide a mechanism for releasing unmanaged resources such as file handles, database connections, and network sockets.
    //When a class implements the IDisposable interface, it must provide a Dispose() method that releases any unmanaged resources it has acquired and performs other cleanup tasks.

    public class DisposableExample : IDisposable
    {
        private readonly FileStream _FileStream;

        public void Dispose()
        {
            _FileStream.Dispose();
        }
    }

    //GC.Colllect() should not be used as it is not thread safe, use Dispose() instead

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //ASYNC and AWAIT Keywords
    //In C#, async/await are keywords used for asynchronous programming, which is a technique for managing long-running operations without blocking the main thread of execution.
    //Asynchronous programming can be useful for improving the responsiveness of user interfaces, managing I/O operations, and other scenarios where long-running operations are needed.
    public class AsyncAwaitExample
    {
        public async Task<int> DownloadFileAsync(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, fileName);
            }

            return 0;
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //INTERFACE Keyword
    //In C#, the interface keyword is used to define a contract for a set of methods and properties that a class must implement.
    //An interface defines a set of signatures for methods and properties that a class must implement, but it does not provide an implementation for those methods or properties.

    public interface IMyInterface
    {
        int MyProperty { get; set; }
        void MyMethod();
    }

    //Note that the interface only defines the signatures of the members, but it does not provide an implementation for them.

    public class InterfaceExample : IMyInterface
    {
        public int MyProperty { get; set; }

        public void MyMethod()
        {
            Console.WriteLine("MyMethod called.");
        }
    }

    //In this example, we're defining a class named MyClass that implements the IMyInterface interface.
    //The class provides an implementation for the MyProperty property and the MyMethod method, which are required by the interface.
    //When a class implements an interface, it must provide an implementation for all of the members defined by the interface.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //STRING and STRINGBUILDER Keywords
    //The string class represents an immutable sequence of characters. Immutable means that once a string object is created, its value cannot be changed
    class StringExample
    {

        void StringExampleMethod()
        {
            string myString = "Hello, world!";
            string mySubstring = myString.Substring(0, 5);
            Console.WriteLine(mySubstring);
        }
    }

    //The StringBuilder class, on the other hand, represents a mutable sequence of characters. Mutable means that the value of the object can be changed.
    public class StringBuilderExample
    {
        void StringBuilderExampleMethod()
        {
            StringBuilder myStringBuilder = new StringBuilder("Hello, ");
            myStringBuilder.Append("world!");
            Console.WriteLine(myStringBuilder.ToString());
        }
    }

    //In general, the string class is more efficient than the StringBuilder class for small strings, because it does not require dynamic memory allocation.
    //However, the StringBuilder class can be much more efficient than the string class for large strings or for operations that involve many concatenations or modifications,
    //because it allows you to modify the string in place rather than creating a new string object each time.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //ARRAY AND ARRAYLIST Keywords
    //The Array keyword is used to create a fixed-size collection of elements of the same type.
    //Arrays have a fixed length that is set when the array is created, and the elements of the array are accessed by index.

    //The ArrayList keyword, on the other hand, is used to create a dynamic collection of elements of any type.
    //ArrayLists can grow or shrink as needed, and the elements of the ArrayList are accessed by index.

    public class ArrayAndArrayListExample
    {
        public void ArrayExample()
        {
            int[] myArray = new int[5];
            myArray[0] = 1;
            myArray[1] = 2;                         //In this example, we're creating an array named myArray that contains five elements of type int.
            myArray[2] = 3;                         //We're then setting the values of the individual elements of the array using the index notation.
            myArray[3] = 4;                         //We're then using the Console.WriteLine method to print the value of the element at index 3 to the console.
            myArray[4] = 5;

            Console.WriteLine(myArray[3]); // Output: 4
        }

        public void ArrayListExample()
        {
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add("two");                 //Adding different types of elements in an ArrayList
            myArrayList.Add(3.0);

            Console.WriteLine(myArrayList[1]); // Output: "two"

        }

    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //GENERICS
    //Generics in C# allow you to define classes, interfaces, and methods that can work with different types of data, while maintaining strong type safety at compile time.
    //Generics can be used to create reusable code that is not tied to a specific data type, and can make code more flexible and easier to maintain.

    public class MyGenericClass<T>
    {
        private T _myData;

        public MyGenericClass(T myData)
        {
            _myData = myData;
        }

        public T GetData()
        {
            return _myData;
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //OVERLOADING

    //In C#, method overloading is a technique that allows you to define multiple methods with the same name but different parameter lists.
    //Method overloading can be useful for providing multiple ways to perform the same operation with different types of input, and can make code more flexible and easier to use.
    //COMPILE TIME - EARLY BINDING

    public class MyMathClass
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public string Add(string a, string b)
        {
            return a + b;
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //OVERRIDING
    //In C#, method overriding is a technique that allows you to provide a new implementation for a method that is already defined in a base class or interface.
    //Method overriding is useful for customizing the behavior of a base class or interface in a derived class, and can make code more flexible and extensible.
    //RUNTIME - LATE BINDING

    public class Animal
    {
        public virtual void Speak()                     //virtual is used to mark the method for later overriding
        {
            Console.WriteLine("The animal speaks.");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()                    //override keyword used to mark that it is Overriding base class Animal
        {
            Console.WriteLine("The dog barks.");
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //INTERFACE VS ABSTRACT Classes

    //An abstract class is a class that cannot be instantiated and may contain both abstract and concrete methods.
    //Abstract classes are used to define a base class that provides a common set of methods and properties that derived classes can inherit and customize.
    //Abstract classes can also define constructors and member variables, and can be used to enforce some level of code reuse.

    public abstract class Animal2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal2(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeSound();
    }

    public class Dog2 : Animal2
    {
        public Dog2(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    //On the other hand, an interface is a contract that defines a set of methods and properties that a class must implement.
    //Interfaces contain only method and property signatures, and do not contain any implementation.
    //Classes can implement one or more interfaces, and can provide their own implementation for each method and property defined in the interface.

    public interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }

        void MakeSound();
    }

    public class Dog3 : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog3(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
    //Key Differences:

    //An abstract class can contain both abstract and concrete methods, while an interface can only contain method and property signatures.
    //A class can only inherit from one abstract class, but can implement multiple interfaces.
    //An abstract class can have member variables and constructors, while an interface cannot.
    //An abstract class can provide some level of code reuse by allowing derived classes to inherit and customize its implementation, while an interface provides a contract that defines the methods and properties that a class must implement.
    //An abstract class can provide a default implementation for some methods, while an interface only provides method signatures.

    //Usage cases:
    //Abstract – Good when you are sure some methods are concrete/defined and must be implemented in the same way in all derived classses
    //Interface -method has to be there, but diff implementation in derived classes

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //PARAMS keyword
    //In C#, params is a keyword that allows you to specify a variable number of arguments for a method or constructor.
    //By using the params keyword, you can specify that the last parameter of a method or constructor is a variable-length parameter list, which allows callers to pass any number of arguments to the method.

    public class ParamsExampleClass
    {
        public int AddNumbers(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }


    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //Exception Handling (Try-Catch)

    //In C#, try and catch are keywords used for handling exceptions.
    //Exceptions are errors or unexpected situations that occur while a program is running, such as a file not being found or a division by zero.
    //By using try and catch blocks, you can write code that gracefully handles exceptions and prevents your program from crashing.

    public class ExceptionHandlerClass
    {
        public void TryCatch()
        {
            try
            {
                // Code that may throw an exception
                int x = 10;
                int y = 0;
                int z = x / y;
            }
            catch (Exception ex)
            {
                // Code to handle the exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //This Keyword

    //In C#, this is a keyword that refers to the current instance of a class. It is used to access the fields, properties, and methods of the current object.
    public class MyClass
    {
        private int _x;

        public MyClass(int x)
        {
            this._x = x;
        }

        public int GetX()
        {
            return this._x;
        }

        public void SetX(int x)
        {
            this._x = x;
        }
    }


    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //USING Keyword
    //In C#, the using keyword is used to define a scope in which an object is created, used, and then disposed of when it is no longer needed.
    //The using statement is used to automatically dispose of an object that implements the IDisposable interface when the scope is exited, even if an exception is thrown.

    public class FileOutput
    {
        public void WriteToFile(string fileName, string text)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] data = Encoding.UTF8.GetBytes(text);
                fs.Write(data, 0, data.Length);
            }
        }
    }

    //In this example, we're creating a new FileStream object and using the using statement to ensure that the object is disposed of when it is no longer needed.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //IS and AS Operators
    //The is operator checks whether an object is of a specified type.
    //It returns true if the object is of the specified type, and false otherwise.

    public class isAsClassExample
    {

        public static void CheckIs()
        {

            isAsClassExample myObject = new isAsClassExample();
            if (myObject is isAsClassExample)
            {
                // myObject is an instance of MyClass
            }
        }
        // AS operator
        //The as operator performs a safe cast of an object to a specified type.
        //If the object is not of the specified type, the result of the as operator is null.

        public static void CheckAs()
        {
            object? myObject = null;
            MyClass myObj = myObject as MyClass;
            if (myObj != null)
            {
                // myObject was successfully cast to MyClass
            }
        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //BOXING and UNBOXING 
    //In C#, boxing and unboxing are mechanisms for converting between value types and reference types.
    //Boxing is the process of converting a value type to an object of type object or another reference type,
    //while unboxing is the reverse process of converting an object of type object or another reference type to a value type.

    //Boxing is typically performed implicitly by the runtime when a value type is assigned to a variable of type object or another reference type.

    public class BoxingUnboxingExample
    {

        //Boxing is typically performed implicitly by the runtime when a value type is assigned to a variable of type object or another reference type.

        public static void BoxingExample()
        {
            int x = 42;
            object obj = x; // implicit boxing of x

        }

        //Unboxing, on the other hand, requires an explicit cast to the appropriate value type.
        public static void UnboxingExample()
        {
            object obj = 42;
            int x = (int)obj; // explicit unboxing of obj

        }
    }

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    //REFLECTION
    //In C#, reflection is a feature that allows you to inspect and manipulate the metadata of types, objects, and assemblies at runtime.

    //With reflection, you can:
    //Discover information about types, such as their properties, methods, fields, and events
    //Create instances of types dynamically
    //Invoke methods and access properties of objects at runtime
    //Modify or create new types at runtime
    //Load and unload assemblies dynamically

    class ReflectionExampleClass
    {
        public int MyProperty { get; set; }
        public void MyMethod()
        {
            Console.WriteLine("Hello, world!");
        }
    }

    //See main code for examples

    //Reflection is typically used in scenarios where you need to work with types or objects dynamically, for example when building a plugin system or a code generator.

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------

    // ----------------------------------------------***********************************************************-------------------------------------------------------------------
    class Program
    {

        public static int Add1(int a, int b)        //Method to be delegated
        { return a + b; }

        public static int Substract1(int a, int b)  //Method to be delegated
        { return a - b; }

        public static void Main(string[] args)
        {
            //Static Usage
            int value = StaticExample.MyStaticField;
            StaticExample.MyStaticMethod();
            Console.WriteLine(value);

            //Ref and Out Usage

            int x = 1;
            RefAndOutExample.IncrementValue(ref x); // passing by reference
            Console.WriteLine(x); // Output: 2

            int a, b; //a and b not initialised
            RefAndOutExample.GetValues(out a, out b); //they are initialised in the method and the value is kept outside of it, as it retains value
            Console.WriteLine(a); // Output: 1
            Console.WriteLine(b); // Output: 2

            //Const and ReadOnly Usage

            int xConstVar = ConstAndReadonlyExample.MyConstant1;
            Console.WriteLine(xConstVar);
            ConstAndReadonlyExample xReadOnly = new ConstAndReadonlyExample(20);
            Console.WriteLine(xReadOnly.MyConstant2);

            //Delegate Usage

            DelegateExample exampleDelegate = Add1;             //We initially delegate Add to be used
            int xDelegate = 10, yDelegate = 5;
            int result = exampleDelegate(xDelegate, yDelegate);
            Console.WriteLine(result);                          //This will use the Add function as above delegated, so it will output 15
            exampleDelegate = Substract1;                       //We now delegate Substract to be used instead of Add
            result = exampleDelegate(xDelegate, yDelegate);
            Console.WriteLine(result);                          //This will use the Substract function as above delegated, so it will output 5

            //Generics Usage

            MyGenericClass<string> myStringClass = new MyGenericClass<string>("Hello, world!");
            string myString = myStringClass.GetData();
            Console.WriteLine(myString);

            MyGenericClass<int> myIntClass = new MyGenericClass<int>(20);
            int aGenericIntExample = myIntClass.GetData();
            Console.WriteLine(aGenericIntExample);

            //Overloading example

            MyMathClass math = new MyMathClass();
            int intResult = math.Add(2, 3);
            double doubleResult = math.Add(2.0, 3.0);
            string stringResult = math.Add("Hello, ", "world!");

            Console.WriteLine(intResult); // Output: 5
            Console.WriteLine(doubleResult); // Output: 5.0
            Console.WriteLine(stringResult); // Output: "Hello, world!"

            //Overriding example

            Animal animal = new Animal();
            Dog dog = new Dog();

            animal.Speak(); // Output: "The animal speaks."
            dog.Speak(); // Output: "The dog barks."

            //Params example

            ParamsExampleClass paramsExample = new ParamsExampleClass();

            int sum1 = paramsExample.AddNumbers(1, 2, 3); // sum1 = 6
            int sum2 = paramsExample.AddNumbers(4, 5, 6, 7, 8); // sum2 = 30
            int sum3 = paramsExample.AddNumbers(9); // sum3 = 9

            //Reflection Example
            Type t = typeof(ReflectionExampleClass);
            PropertyInfo[] properties = t.GetProperties();
            MethodInfo[] methods = t.GetMethods();
            Console.WriteLine("Properties:");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("- " + property.Name);
            }
            Console.WriteLine("Methods:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("- " + method.Name);
            }


        }
    }
}