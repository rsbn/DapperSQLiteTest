using DbAccess;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> list = DataAccess.GetPeople();
            foreach (var p in list)
            {
                Console.WriteLine($"{p.FisrtName} {p.LastName} - {p.Car?.Model} {p.Car?.Year}");
            }

            Console.ReadLine();
        }
    }
}
