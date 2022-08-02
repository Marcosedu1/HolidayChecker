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
                var checkingDate = new CheckHoliday(date);

                checkingDate.CheckIsHoliday();
            }
        }
    }
}

//Dois pontos depois da classe é vai receber herança de outra classe
//Classe abstrata só serve para ser herdada por outra classe, metodos abstratos devem ser sebrescrevidos
//Polimorfismo

//Interface - faz a comunicação entre o usuario e o sistema
//Qualquer coisa que sirva de comunicação entre duas coisas é uma interace
//Quando definido um comportamento no Interface, é obrigatorio o uso do método
//Interace também é chamado de contrato 
