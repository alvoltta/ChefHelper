using System;
using Volta.ChefHelperBL.Controller;

namespace Volta.ChefHelperView
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chef Helper App.");
            Console.WriteLine("Write name of your Organization.");

            var name = Console.ReadLine();
            var organizationController = new OrganizationController(name);      }
    }
}
