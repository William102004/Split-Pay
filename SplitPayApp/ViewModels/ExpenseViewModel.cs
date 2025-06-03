using System;
using System.Collections.ObjectModel;
using Split_Pay_Libraries.Models;
using Split_Pay_Libraries.Services;
using Split_Play_Libraries.Models;
using Split_Play_Libraries.Services;

namespace SplitPayApp.ViewModels;

public class ExpenseViewModel : BaseViewModel
{
    private ExpenseService ExpenseService = ExpenseService.Current;

    public Expense? SelectedExpense { get; set; }
    private FamilyMember? SelectedFamilyMember { get; set; }

    public double HouseholdBalance => HouseHoldService.Current.HouseholdBalance;

    public ObservableCollection<FamilyMember?> FamilyMembers
    {
        get
        {
            return new ObservableCollection<FamilyMember?>(HouseHoldService.Current.Household.Where(m => m != null));

        }
    }
    public string? Name
    {
        get
        {
            return SelectedExpense?.name ?? string.Empty;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.name != value)
            {
                SelectedExpense.name = value;

            }
        }
    }
    public double Amount
    {
        get
        {
            return SelectedExpense?.amount ?? 0.0;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.amount != value)
            {
                SelectedExpense.amount = value;
            }
        }
    }
    public int Month
    {
        get
        {
            return SelectedExpense?.month ?? DateTime.Now.Month;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.month != value)
            {
                SelectedExpense.month = value;
            }
        }
    }
    public int Year
    {
        get
        {
            return SelectedExpense?.year ?? DateTime.Now.Year;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.year != value)
            {
                SelectedExpense.year = value;
            }
        }
    }
    public int Day
    {
        get
        {
            return SelectedExpense?.Day ?? DateTime.Now.Day;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.Day != value)
            {
                SelectedExpense.Day = value;
            }
        }
    }
    public string? Category
    {
        get
        {
            return SelectedExpense?.category ?? string.Empty;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.category != value)
            {
                SelectedExpense.category = value;
            }
        }
    }
    public string? Description
    {
        get
        {
            return SelectedExpense?.description ?? string.Empty;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.description != value)
            {
                SelectedExpense.description = value;
            }
        }
    }
    public bool Recurring
    {
        get
        {
            return SelectedExpense?.Recurring ?? false;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.Recurring != value)
            {
                SelectedExpense.Recurring = value;
            }
        }
    }
    public string? Frequency
    {
        get
        {
            return SelectedExpense?.frequency ?? string.Empty;
        }
        set
        {
            if (SelectedExpense != null && SelectedExpense.frequency != value)
            {
                SelectedExpense.frequency = value;
            }
        }
    }

    public void RefreshExpenses()
    {
        NotifyPropertyChanged(nameof(FamilyMembers));
        NotifyPropertyChanged(nameof(HouseholdBalance));
    }

    public void AddExpense()
    {
        if (SelectedFamilyMember != null && !string.IsNullOrEmpty(Name) && Amount > 0)
        {
            ExpenseService.AddExpense(SelectedFamilyMember.id, Name, Amount, Month, Year, Day, Category, Description, Recurring, Frequency);
        }

        Name = string.Empty;
        Amount = 0.0;
        Month = DateTime.Now.Month;
        Year = DateTime.Now.Year;
        Day = DateTime.Now.Day;
        Category = string.Empty;
        Description = string.Empty;
        Recurring = false;
        Frequency = string.Empty;
        SelectedExpense = null;

        RefreshExpenses();
    }

    public void RemoveExpense()
    {
        ExpenseService.RemoveExpense(SelectedExpense?.id ?? 0);
        RefreshExpenses();
    }



}   
