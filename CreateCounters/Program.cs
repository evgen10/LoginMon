using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security;

namespace CreateCounters
{
    class Program
    {
        private const string CategoryName = "MusStoreCounters";

        private static void Create()
        {            
            CounterCreationDataCollection counterCreationDataCollection = new CounterCreationDataCollection()
            {
                new CounterCreationData()
                {
                    CounterName = "LogInSuccess",
                    CounterType = PerformanceCounterType.NumberOfItems32
                },

                new CounterCreationData()
                {
                    CounterName = "LogOffSuccess",
                    CounterType = PerformanceCounterType.NumberOfItems32
                },

                new CounterCreationData()
                {
                    CounterName = "GoToHome",
                    CounterType = PerformanceCounterType.NumberOfItems32
                }
            };

            if (!PerformanceCounterCategory.Exists(CategoryName))
            {
                try
                {
                    PerformanceCounterCategory.Create(
                        CategoryName, "",
                        PerformanceCounterCategoryType.MultiInstance,
                        counterCreationDataCollection);

                    Console.WriteLine("Category created");
                }
                catch (SecurityException)
                {
                    Console.WriteLine("Do not have permissions");
                }                
            }
            else
            {
                Console.WriteLine("Counters alredy exsits");
            }
        }

        private static void Delete()
        {
            if (PerformanceCounterCategory.Exists(CategoryName))
            {
                try
                {
                    PerformanceCounterCategory.Delete(CategoryName);
                    Console.WriteLine("Category deleted");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Do not have permissions");
                }                
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to create counters");
            Console.WriteLine("Enter 2 to delete counters");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        {
                            Create();
                            break;
                        }
                    case 2:
                        {
                            Delete();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Wrong value");
                            break;
                        }                        
                }
            }
            else
            {
                Console.WriteLine("Wrong value");
            }
            
            Console.Read();
        }
    }
}
