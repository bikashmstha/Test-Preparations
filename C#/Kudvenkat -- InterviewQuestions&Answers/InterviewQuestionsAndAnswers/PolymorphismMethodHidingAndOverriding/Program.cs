using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    //https://www.akadia.com/services/dotnet_polymorphism.html
    //http://www.dotnettricks.com/learn/csharp/understanding-virtual-override-and-new-keyword-in-csharp
    class Program
    {  
        public static void Main()
        {
            
        }
    }
}

//Overview

//One of the fundamental concepts of object oriented software development is polymorphism.The term polymorphism(from the Greek meaning "having multiple forms") in OO is the characteristic of being able to assign a different meaning or usage to something in different contexts - specifically, to allow a variable to refer to more than one type of object.

//Example Class Hierarchy

//Let's assume the following simple class hierarchy with classes A, B and C for the discussions in this text. A is the super- or base class, B is derived from A and C is derived from class B. In some of the easier examples, we will only refer to a part of this class hierarchy.



//Inherited Methods

//A method Foo() which is declared in the base class A and not redeclared in classes B or C is inherited in the two subclasses

//    using System;
//    namespace Polymorphism
//{
//    class A
//    {
//        public void Foo() { Console.WriteLine("A::Foo()"); }
//    }

//    class B : A { }

//    class Test
//    {
//        static void Main(string[] args)
//        {
//            A a = new A();
//            a.Foo();  // output --> "A::Foo()"

//            B b = new B();
//            b.Foo();  // output --> "A::Foo()"
//        }
//    }
//}


//The method Foo() can be overridden in classes B and C:

//    using System;
//    namespace Polymorphism
//{
//    class A
//    {
//        public void Foo() { Console.WriteLine("A::Foo()"); }
//    }

//    class B : A
//    {
//        public void Foo() { Console.WriteLine("B::Foo()"); }
//    }

//    class Test
//    {
//        static void Main(string[] args)
//        {
//            A a;
//            B b;

//            a = new A();
//            b = new B();
//            a.Foo();  // output --> "A::Foo()"
//            b.Foo();  // output --> "B::Foo()"

//            a = new B();
//            a.Foo();  // output --> "A::Foo()"
//        }
//    }
//}


//There are two problems with this code.

//The output is not really what we, say from Java, expected.The method Foo() is a non-virtual method.C# requires the use of the keyword virtual in order for a method to actually be virtual. An example using virtual methods and polymorphism will be given in the next section.
//Although the code compiles and runs, the compiler produces a warning:
//...\polymorphism.cs(11,15): warning CS0108: The keyword new is required on 'Polymorphism.B.Foo()' because it hides inherited member 'Polymorphism.A.Foo()'

//This issue will be discussed in section Hiding and Overriding Methods.

//Virtual and Overridden Methods

//Only if a method is declared virtual, derived classes can override this method if they are explicitly declared to override the virtual base class method with the override keyword.

//    using System;
//    namespace Polymorphism
//{
//    class A
//    {
//        public virtual void Foo() { Console.WriteLine("A::Foo()"); }
//    }

//    class B : A
//    {
//        public override void Foo() { Console.WriteLine("B::Foo()"); }
//    }

//    class Test
//    {
//        static void Main(string[] args)
//        {
//            A a;
//            B b;

//            a = new A();
//            b = new B();
//            a.Foo();  // output --> "A::Foo()"
//            b.Foo();  // output --> "B::Foo()"

//            a = new B();
//            a.Foo();  // output --> "B::Foo()"
//        }
//    }
//}

//Method Hiding

//Why did the compiler in the second listing generate a warning? Because C# not only supports method overriding, but also method hiding. Simply put, if a method is not overriding the derived method, it is hiding it. A hiding method has to be declared using the new keyword. The correct class definition in the second listing is thus:

//    using System;
//    namespace Polymorphism
//{
//    class A
//    {
//        public void Foo() { Console.WriteLine("A::Foo()"); }
//    }

//    class B : A
//    {
//        public new void Foo() { Console.WriteLine("B::Foo()"); }
//    }

//    class Test
//    {
//        static void Main(string[] args)
//        {
//            A a;
//            B b;

//            a = new A();
//            b = new B();
//            a.Foo();  // output --> "A::Foo()"
//            b.Foo();  // output --> "B::Foo()"

//            a = new B();
//            a.Foo();  // output --> "A::Foo()"
//        }
//    }
//}

//Combining Method Overriding and Hiding

//Methods of a derived class can both be virtual and at the same time hide the derived method.In order to declare such a method, both keywords virtual and new have to be used in the method declaration:

//            class A
//{
//    public void Foo() { }
//}

//class B : A
//{
//    public virtual new void Foo() { }
//}


//A class C can now declare a method Foo() that either overrides or hides Foo() from class B :

//            class C : B
//{
//    public override void Foo() { }
//    // or
//    public new void Foo() { }
//}

//Conclusion

//C# is not Java.
//Only methods in base classes need not override or hide derived methods.All methods in derived classes require to be either defined as new or as override.
//Know what your doing and look out for compiler warnings.