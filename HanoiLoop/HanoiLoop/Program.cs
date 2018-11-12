using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string input;
            HanoiTower tower = new HanoiTower();
            Console.WriteLine("Please input a number for the level of Hanoi Tower...");
            input = Console.ReadLine();
            if (int.TryParse(input, out n))
                tower.run(n);
            else
                Console.WriteLine("This is not a valid number");
        }
    }
}
