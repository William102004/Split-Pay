using System;
using Split_Pay_Libraries.Models;
using Split_Pay_Libraries.Services;
using Split_Play_Libraries.Models;

namespace Split_Play_Libraries.Services;

public class ExpenseService
{
    private ExpenseService()
    {
        Expenses = new List<Expense?>();
    }

    private int LastKey
    {
        get
        {
            if (!Expenses.Any())
            {
                return 0;
            }

            return Expenses.Select(E => E?.id ?? 0).Max();
        }
    }
    private static ExpenseService? instance;
    private static object instanceLock = new object();
    public static ExpenseService Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new ExpenseService();
                }
            }

            return instance;
        }
    }
    public List<Expense?> Expenses { get; private set; }

    public Expense AddExpense(int id, string Name, double Amount, int Month, int year, int day, string category, string description, bool recurring, string frequency)
    {
        int newId = LastKey + 1;
        Expense expense = new Expense(newId, Name, Amount, Month, year, day, category, description, recurring, frequency);
        Expenses.Add(expense);
        FamilyMember? familyMember = HouseHoldService.Current.Household.FirstOrDefault(f => f?.id == id);
        if (familyMember != null)
        {
            familyMember.balance = Math.Round((double)(familyMember.balance ?? 0) - Amount, 2);
        }
        return expense;

    }
    public Expense? GetExpense(int id)
    {
        return Expenses.FirstOrDefault(e => e?.id == id);
    }
    public List<Expense?> GetAllExpenses()
    {
        return Expenses.ToList();
    }



}
