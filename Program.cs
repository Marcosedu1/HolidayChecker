using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIsHoliday
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome To The Ultimate Brazilian National Holiday Checker Ever Made!\n");
            Console.WriteLine("Please, Enter a date for checking (DD/MM/YYYY)");
            string dateString = Console.ReadLine();

            DateTime date;
            if (dateString == "")
            {
                Console.WriteLine("Ending Program");
            }
            else
            {
                while (!DateTime.TryParse(dateString, out date))
                {
                    Console.WriteLine("Please, enter a valid date!");
                    dateString = Console.ReadLine();
                    if (dateString == "")
                    {
                        break;
                    }
                }
                CheckHoliday checkingDate = new CheckHoliday(date);

                checkingDate.CheckIsHoliday();
            }
        }
    }
}