using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanUStoreDifferentTypesInAnArray
{
    #region  
//Another alternative is to use ArrayList class that is present in System.Collections namespace.
//class Program
//{
//    static void Main()
//    {
//        System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
//        arrayList.Add(101); // integer
//        arrayList.Add("C#"); // integer

//        Customer c = new Customer();
//        c.ID = 99;
//        c.Name = "Pragim";

//        arrayList.Add(c); // Customer - Complext Type 

//        // loop thru the array and retrieve the items
//        foreach (object obj in arrayList)
//        {
//            Console.WriteLine(obj);
//        }
//        Console.ReadLine();
//    }
//}

#endregion
    class Program
    {
        //static void Main(string[] args)
        //{

        //}
        static void Main()
        {
            object[] objectArray = new object[3];
            objectArray[0] = 101; // integer
            objectArray[1] = "C#"; // string

            Customer c = new Customer();
            c.ID = 99;
            c.Name = "Pragim";

            objectArray[2] = c; // Customer - Complext Type 

            // loop thru the array and retrieve the items
            foreach (object obj in objectArray)
            {
                Console.WriteLine(obj);
                
            }
            Console.ReadLine();
        }
    }
    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        

        public override string ToString()
        {
            return this.Name;
        }
    }
}

