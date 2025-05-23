// See https://aka.ms/new-console-template for more information
using System;
using Split_Pay_Libraries.Services;
using Split_Pay_Libraries.Models;

namespace SplitPay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FamilyMember?> Household = HouseHoldService.Current.Household;
            Console.WriteLine("Welcome to SplitPay!");
            Console.WriteLine("Please create your account:");
            Console.WriteLine("Please enter your name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Please enter your email:");
            string? email = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            string? phone = Console.ReadLine();
            Console.WriteLine("Please enter your address:");
            string? address = Console.ReadLine();
            Console.WriteLine("Please enter your balance:");
            double? balance = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Please enter name for the Household:");
            
        }
    }
}