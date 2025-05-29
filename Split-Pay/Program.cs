// See https://aka.ms/new-console-template for more information
using System;
using Split_Pay_Libraries.Services;
using Split_Pay_Libraries.Models;
using System.Collections;
using System.Diagnostics;
using System.Xml.Serialization;
using Split_Play_Libraries.Models;
using Split_Play_Libraries.Services;
/*
namespace SplitPay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expense?> Expenses = ExpenseService.Current.Expenses;
            List<FamilyMember?> Household = HouseHoldService.Current.Household;
            Console.WriteLine("Welcome to SplitPay!");
            Console.WriteLine("A family expense tracker.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please enter name for the Household:");
            string? HouseName = Console.ReadLine();
            if( HouseName == null || HouseName == "")
            {
                HouseName = "Household";
            }
            HouseHoldService.Current.HouseHoldName = HouseName;
            Console.WriteLine("Welcome to " + HouseName + "!");

            char? Choice;
            bool running = true;

            while (running)
            {
                Console.WriteLine("Plese select an option:");
                Console.WriteLine("A. Manage Family Members");
                Console.WriteLine("B. Manage Expenses");
                Console.WriteLine("C. View Household Balance");
                Console.WriteLine("Q.Exit");
                string? input = Console.ReadLine();
                if (input == null || input == "")
                {
                    Choice = 'Q';
                }
                else
                {
                    Choice = input[0];
                }

                switch (Choice)
                    {
                        case 'A':
                        case 'a':
                            Console.WriteLine("Manage Family Members");
                            Console.WriteLine("A. Add Family Member");
                            Console.WriteLine("B. View Family Members");
                            Console.WriteLine("C. Remove Family Member");
                            Console.WriteLine("D. Update Member Balance");
                            Console.WriteLine("E. Back to Main Menu");
                            char? ChoiceFamily;
                            input = Console.ReadLine();
                            if (input == null || input == "")
                            {
                                 ChoiceFamily = 'F';
                            }
                            else
                            {
                                ChoiceFamily = input[0];
                            }
                        switch (ChoiceFamily)
                        {
                            case 'A':
                            case 'a':
                                Console.WriteLine("Enter Family Member Name:");
                                string? name = Console.ReadLine();
                                Console.WriteLine("Enter Family Member Email:");
                                string? email = Console.ReadLine();
                                Console.WriteLine("Enter Family Member Phone:");
                                string? phone = Console.ReadLine();
                                Console.WriteLine("Enter Family Member Address:");
                                string? address = Console.ReadLine();
                                Console.WriteLine("Enter Family Member Balance:");
                                double balance = Convert.ToDouble(Console.ReadLine());
                                HouseHoldService.Current.AddFamilyMember(name, email, phone, address, balance);
                                break;
                            case 'B':
                            case 'b':
                                Console.WriteLine("Family Members:");
                                var members = HouseHoldService.Current.GetHouseHoldMembers();
                                if (!members.Any())
                                {
                                    Console.WriteLine("No family members found.");
                                }
                                else
                                {
                                    foreach (var member in members)
                                    {
                                        Console.WriteLine(member?.Display);
                                    }
                                }
                                break;

                            case 'C':
                            case 'c':
                                Console.WriteLine("Enter Family Member ID to remove:");
                                int? id = int.Parse(Console.ReadLine());
                                if (id == null)
                                {
                                    Console.WriteLine("Invalid ID.");
                                    break;
                                }
                                else
                                {
                                    HouseHoldService.Current.RemoveFamilyMember((int)id);
                                }
                                break;
                            case 'D':
                            case 'd':
                                Console.WriteLine("Enter Family Member ID to update balance:");
                                int? idToUpdate = int.Parse(Console.ReadLine());
                                if (idToUpdate == null)
                                {
                                    Console.WriteLine("Invalid ID.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter new balance:");
                                    double newBalance = Convert.ToDouble(Console.ReadLine());
                                    HouseHoldService.Current.UpdateMemberBalance((int)idToUpdate, newBalance);
                                }
                                break;
                            case 'E':
                            case 'e':
                                Console.WriteLine("Back to Main Menu");
                                break;
                        }
                            break;
                        case 'B':
                        case 'b':
                            Console.WriteLine("Manage Expenses");
                            Console.WriteLine("A. Add Expense");
                            Console.WriteLine("B. View Expenses");
                            Console.WriteLine("C. Remove Expense");
                            Console.WriteLine("D. Back to Main Menu");
                            input = Console.ReadLine();
                            char? ChoiceExpense;
                            if (input == null || input == "")
                            {
                                ChoiceExpense = 'D';
                            }
                            else
                            {
                                ChoiceExpense = input[0];
                            }
                        switch (ChoiceExpense)
                        {
                            case 'A':
                            case 'a':
                                Console.WriteLine("Enter Family Member ID:");
                                int? id = int.Parse(Console.ReadLine());
                                if (id == null)
                                {
                                    Console.WriteLine("Invalid ID.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter Expense Name:");
                                    string? name = Console.ReadLine();
                                    Console.WriteLine("Enter Expense Amount:");
                                    double amount = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Enter Expense Month:");
                                    int month = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Expense Year:");
                                    int year = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Expense Day:");
                                    int day = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Expense Category:");
                                    string category = Console.ReadLine();
                                    Console.WriteLine("Enter Expense Description:");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Is this a recurring expense? (y/n):");
                                    bool recurring = Console.ReadLine()?.ToLower() == "y";
                                    string? frequency = string.Empty;
                                    if (recurring)
                                    {
                                        Console.WriteLine("Enter frequency (e.g., weekly, monthly):");
                                        frequency = Console.ReadLine();
                                    }
                                    ExpenseService.Current.AddExpense((int)id, name, amount, month, year, day, category, description, recurring, frequency);
                                }
                                break;
                            case 'B':
                            case 'b':
                                Console.WriteLine("Expenses:");
                                var expenses = ExpenseService.Current.GetAllExpenses();
                                if (!expenses.Any())
                                {
                                    Console.WriteLine("No expenses found.");
                                }
                                else
                                {
                                    foreach (var familyMember in Household)
                                    {
                                        Console.WriteLine(familyMember?.Display);
                                        if (familyMember?.expenses == null || familyMember?.expenses.Count == 0)
                                        {
                                            Console.WriteLine("No expenses found for this member.");
                                            continue;
                                        }
                                        else
                                        {
                                            foreach (var expense in familyMember?.expenses)
                                            {
                                                Console.WriteLine(expense?.Display);
                                            }
                                        }
                                    }
                                }
                                break;
                            case 'C':
                            case 'c':
                                Console.WriteLine("Enter Expense ID to remove:");
                                int? expenseId = int.Parse(Console.ReadLine());
                                if (expenseId == null)
                                {
                                    Console.WriteLine("Invalid ID.");
                                    break;
                                }
                                else
                                {
                                    ExpenseService.Current.RemoveExpense((int)expenseId);
                                }
                                break;
                            case 'D':
                            case 'd':
                                Console.WriteLine("Back to Main Menu");
                                break;    
                        }
                            break;
                        case 'C':
                        case 'c':
                            Console.WriteLine("Household Balance: " + HouseHoldService.Current.HouseholdBalance);
                            break;
                        case 'Q':
                        case 'q':
                            Console.WriteLine("Exiting...");
                            Console.WriteLine("Thank you for using SplitPay!");
                            Console.WriteLine("Goodbye!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

            }
        }
    }
}*/