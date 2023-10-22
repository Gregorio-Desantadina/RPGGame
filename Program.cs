using System;
using MyGameProject.Game.Start;

namespace MyGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Main main = new Main();
            main.Start();
            Console.Write("THIS is a ReadLine example... Insert a number:");
            string number = Console.ReadLine();
        }
    }
}

