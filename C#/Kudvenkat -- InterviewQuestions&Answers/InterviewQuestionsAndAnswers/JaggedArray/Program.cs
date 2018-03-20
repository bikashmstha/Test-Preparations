using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    //what is jagged array?
    //A jagged array is an array of arrays.

    class Program
    {
        //static void Main(string[] args)
        //{
        //}
        public static void Main()
        {
            // Create a string array to store the names of the employees
            string[] employeeNames = new string[3];
            employeeNames[0] = "Mark";
            employeeNames[1] = "Matt";
            employeeNames[2] = "John";

            // Create a jagged array. As we want to store varying number of qualifications 
            // and as qualifications are strings, let's create an array of string arrays.
            string[][] jaggedArray = new string[3][];

            // Set the size of the first string array to 3, as we want to store 3 qualifications for Mark
            jaggedArray[0] = new string[3];
            // Set the size of the second string array to 1, as we want to store 
            // only 1 qualification for Matt
            jaggedArray[1] = new string[1];
            // Set the size of the third string array to 2, as we want to store 2 qualifications for John
            jaggedArray[2] = new string[2];

            // Set the values for the first string array
            jaggedArray[0][0] = "Bachelor";
            jaggedArray[0][1] = "Master";
            jaggedArray[0][2] = "Doctorate";
            // Set the values for the second string array
            jaggedArray[1][0] = "Bachelor";
            // Set the values for the thrid string array
            jaggedArray[2][0] = "Bachelor";
            jaggedArray[2][1] = "Master";

            // Loop thru and print out the elements of Jagged array
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(employeeNames[i]);
                Console.WriteLine("--------");
                string[] innerArray = jaggedArray[i];
                for (int j = 0; j < innerArray.Length; j++)
                {
                    Console.WriteLine(innerArray[j]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
