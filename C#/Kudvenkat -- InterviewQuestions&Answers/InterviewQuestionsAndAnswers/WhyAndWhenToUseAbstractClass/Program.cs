using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {

        //Why and when should we use an abstract class?
        //This question can also be asked in a slightly different way
        //Give an example of where we could use an abstract class?

        //Let us understand when to use an abstract class with an example.An organisation has 2 types of 
        //employees
        //1. FullTimeEmployee
        //2. ContractEmployee


        #region Case/Design 1: Without Using Base Class
        //public class FullTimeEmployee
        //{
        //    public int ID { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public int AnnualSalary { get; set; }

        //    public string GetFullName()
        //    {
        //        return this.FirstName + " " + LastName;
        //    }

        //    public int GetMonthlySalary()
        //    {
        //        return this.AnnualSalary / 12;
        //    }
        //}

        //public class ContractEmployee
        //{
        //    public int ID { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public int HourlyPay { get; set; }
        //    public int TotalHoursWorked { get; set; }

        //    public string GetFullName()
        //    {
        //        return this.FirstName + " " + LastName;
        //    }

        //    public int GetMonthlySalary()
        //    {
        //        return this.HourlyPay * this.TotalHoursWorked;
        //    }
        //}

        //public static void Main()
        //{
        //    FullTimeEmployee fte = new FullTimeEmployee()
        //    {
        //        ID = 101,
        //        FirstName = "David",
        //        LastName = "Pie",
        //        AnnualSalary = 60000
        //    };

        //    Console.WriteLine(fte.GetFullName());
        //    Console.WriteLine(fte.GetMonthlySalary());

        //    Console.WriteLine("-------------");

        //    ContractEmployee cte = new ContractEmployee()
        //    {
        //        ID = 102,
        //        FirstName = "Sam",
        //        LastName = "Brooks",
        //        HourlyPay = 100,
        //        TotalHoursWorked = 40
        //    };

        //    Console.WriteLine(cte.GetFullName());
        //    Console.WriteLine(cte.GetMonthlySalary());

        //    Console.Read();
        //}
        #endregion

        //Notice that, we have designed FullTimeEmployee and ContractEmployee classes as stand-alone classes.
        //Regardless of the employee type, all employees in the organisation are going to have ID, FirstName 
        //and LastName properties. We also compute the FullName of any employee by concatenating their FirstName 
        //and LastName. This means that, the above two classes (FullTimeEmployee & ContractEmployee) are related 
        //and there is, a lot of common functionality duplicated in them.The problem with this design is that, 
        //tomorrow, if want to introduce MiddleName property and if we have to include it in the computation of 
        //FullName, then we have to make the same change in both the classes.So code maintainability is going to 
        //be a big issue with this design.

        //To avoid these issues, we can move the common functionality into a base class. Using a common base class, 
        //we are going to get rid of the duplicated code.

        //The obvious next question is, How should we design the base class?
        //1. Should we design it as an abstract class
        //OR
        //2. Should we design it as a Concrete(Non abstract) class

        //Let's see what's going to happen, if we design the base class as a concrete class. 
        //All the common code is now present in BaseEmployee class.       

        #region Case/Design 2: concrete class as base class
        //public class BaseEmployee
        //{
        //    public int ID { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }

        //    public string GetFullName()
        //    {
        //        return this.FirstName + " " + LastName;
        //    }

        //    public virtual int GetMonthlySalary()
        //    {
        //        //return 0;
        //        throw new NotImplementedException();
        //    }
        //}

        ////Notice that, now the "FullTimeEmployee" class inherits from "BaseEmployee" class and has only the 
        ////code that is specific to it.
        //public class FullTimeEmployee : BaseEmployee
        //{
        //    public int AnnualSalary { get; set; }

        //    public override int GetMonthlySalary()
        //    {
        //        return this.AnnualSalary / 12;
        //    }
        //}

        ////Along the same lines, "ContractEmployee" class inherits from "BaseEmployee" class and has only the 
        ////code that is specific to it.
        //public class ContractEmployee : BaseEmployee
        //{
        //    public int HourlyPay { get; set; }
        //    public int TotalHoursWorked { get; set; }

        //    public override int GetMonthlySalary()
        //    {
        //        return this.HourlyPay * this.TotalHoursWorked;
        //    }
        //}

        //public static void Main()
        //{
        //    FullTimeEmployee fte = new FullTimeEmployee()
        //    {
        //        ID = 101,
        //        FirstName = "David",
        //        LastName = "Pie",
        //        AnnualSalary = 60000
        //    };

        //    Console.WriteLine(fte.GetFullName());
        //    Console.WriteLine(fte.GetMonthlySalary());

        //    Console.WriteLine("-------------");

        //    ContractEmployee cte = new ContractEmployee()
        //    {
        //        ID = 102,
        //        FirstName = "Sam",
        //        LastName = "Brooks",
        //        HourlyPay = 100,
        //        TotalHoursWorked = 40
        //    };

        //    Console.WriteLine(cte.GetFullName());
        //    Console.WriteLine(cte.GetMonthlySalary());

        //    Console.Read();
        //}

        ////So, with the above design we got rid of duplicated code, but we introduced another problem.
        ////Since "BaseEmployee " is a concrete (Non abstract) class, there is nothing stopping us from 
        ////creating an instance of BaseEmployee class and using it. In the Main() method, someone could 
        ////instantiate "BaseEmployee" class as shown below.

        ////public static void Main()
        ////{
        ////    BaseEmployee be = new BaseEmployee()
        ////    {
        ////        ID = 101,
        ////        FirstName = "David",
        ////        LastName = "Pie",
        ////    };

        ////    Console.WriteLine(be.GetFullName());
        ////    Console.WriteLine(be.GetMonthlySalary());
        ////    Console.Read();
        ////}
        #endregion

        //The above design is bad for 2 reasons
        //1. We only have 2 types of employees in our organisation - ContractEmployee  & FullTimeEmployee.
        //   The developers should only able to instantiate ContractEmployee  & FullTimeEmployee classes and 
        //   not BaseEmployee class.
        //2. We get a run time error, if we invoke GetMonthlySalary() method on BaseEmployee class.

        //To get rid of the second issue, we can make the following modifications
        //1. Remove GetMonthlySalary() virtual method from BaseEmployee class
        //2. Remove "override" keyword from GetMonthlySalary() method in ContractEmployee and FullTimeEmployee 
        //   classes.

        //With the above changes, we won't get the runtime error, but we would still be able to instantiate BaseEmployee class. So to prevent BaseEmployee class from being instantiated, let's mark it as an abstract class.

        //One more change is to introduce GetMonthlySalary() as an abstract method in BaseEmployee class. This 
        //will ensure that, all the classes that derive from BaseEmployee class, 
        //1. Will either provide implementation for GetMonthlySalary() method
        //OR
        //2. The derived class will also be marked as an abstract class.

        //With the above changes the design looks as shown below.

        #region Case/Design 3 : abstract class as base class

        public abstract class BaseEmployee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string GetFullName()
            {
                return this.FirstName + " " + LastName;
            }

            public abstract int GetMonthlySalary();
        }

        public class FullTimeEmployee : BaseEmployee
        {
            public int AnnualSalary { get; set; }

            public override int GetMonthlySalary()
            {
                return this.AnnualSalary / 12;
            }
        }

        public class ContractEmployee : BaseEmployee
        {
            public int HourlyPay { get; set; }
            public int TotalHoursWorked { get; set; }

            public override int GetMonthlySalary()
            {
                return this.HourlyPay * this.TotalHoursWorked;
            }
        }

        public static void Main()
        {
            FullTimeEmployee fte = new FullTimeEmployee()
            {
                ID = 101,
                FirstName = "David",
                LastName = "Pie",
                AnnualSalary = 60000
            };

            Console.WriteLine(fte.GetFullName());
            Console.WriteLine(fte.GetMonthlySalary());

            Console.WriteLine("-------------");

            ContractEmployee cte = new ContractEmployee()
            {
                ID = 102,
                FirstName = "Sam",
                LastName = "Brooks",
                HourlyPay = 100,
                TotalHoursWorked = 40
            };

            Console.WriteLine(cte.GetFullName());
            Console.WriteLine(cte.GetMonthlySalary());

            Console.Read();
        }
        #endregion
        //So, in short, we would create an abstract class, when want to move the common functionality of 2 or more 
        //related classes into a base class and when, we don't want that base class to be instantiated.

    }
}
