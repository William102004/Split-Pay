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
            Console.WriteLine("A family expense tracker.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please enter name for the Household:");
            string? HouseName = Console.ReadLine();
           
            
            

            
        }
    }
}