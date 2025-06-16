using System;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using Split_Pay_Libraries.Models;
using Split_Pay_Libraries.Services;
using Split_Play_Libraries.Models;
using Split_Play_Libraries.Services;
using SplitPayApp.ViewModels;

namespace SplitPayApp.ViewModels;

public class ExpenseViewModel : BaseViewModel
{
    private ExpenseService ExpenseService = ExpenseService.Current;
   
    private HouseHoldService HouseHoldService = HouseHoldService.Current;
    private Expense? _selectedExpense;
    private FamilyMember? _selectedExpenseMember;

    public Expense? SelectedExpense
    {
        get => _selectedExpense;
        set
        {
            _selectedExpense = value;
            NotifyPropertyChanged();
            // Notify all expense properties
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Amount));
            NotifyPropertyChanged(nameof(Month));
            NotifyPropertyChanged(nameof(Year));
            NotifyPropertyChanged(nameof(Day));
            NotifyPropertyChanged(nameof(Category));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Recurring));
            NotifyPropertyChanged(nameof(Frequency));
        }
    }

    public FamilyMember? SelectedExpenseMember
    {
        get => _selectedExpenseMember;
        set
        {
            _selectedExpenseMember = value;
            NotifyPropertyChanged();
        }
    }

    public double HouseholdBalance => HouseHoldService.Current.HouseholdBalance;

    public ObservableCollection<FamilyMember?> FamilyMembers
    {
        get
        {
            return new ObservableCollection<FamilyMember?>(HouseHoldService.Household);
        }
    }

    public string? Name
    {
        get => SelectedExpense?.name ?? string.Empty;
        set
        {
            if (SelectedExpense != null && SelectedExpense.name != value)
            {
                SelectedExpense.name = value;
                NotifyPropertyChanged();
            }
        }
    }
    
    public double Amount
    {
        get => SelectedExpense?.amount ?? 0.0;
        set
        {
            if (SelectedExpense != null && SelectedExpense.amount != value)
            {
                SelectedExpense.amount = value;
                NotifyPropertyChanged();
            }
        }
    }

    public int Month
    {
        get => SelectedExpense?.month ?? DateTime.Now.Month;
        set
        {
            if (SelectedExpense != null && SelectedExpense.month != value)
            {
                SelectedExpense.month = value;
                NotifyPropertyChanged();
            }
        }
    }

    public int Year
    {
        get => SelectedExpense?.year ?? DateTime.Now.Year;
        set
        {
            if (SelectedExpense != null && SelectedExpense.year != value)
            {
                SelectedExpense.year = value;
                NotifyPropertyChanged();
            }
        }
    }

    public int Day
    {
        get => SelectedExpense?.Day ?? DateTime.Now.Day;
        set
        {
            if (SelectedExpense != null && SelectedExpense.Day != value)
            {
                SelectedExpense.Day = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Category
    {
        get => SelectedExpense?.category ?? string.Empty;
        set
        {
            if (SelectedExpense != null && SelectedExpense.category != value)
            {
                SelectedExpense.category = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Description
    {
        get => SelectedExpense?.description ?? string.Empty;
        set
        {
            if (SelectedExpense != null && SelectedExpense.description != value)
            {
                SelectedExpense.description = value;
                NotifyPropertyChanged();
            }
        }
    }

    public bool Recurring
    {
        get => SelectedExpense?.Recurring ?? false;
        set
        {
            if (SelectedExpense != null && SelectedExpense.Recurring != value)
            {
                SelectedExpense.Recurring = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string? Frequency
    {
        get => SelectedExpense?.frequency ?? string.Empty;
        set
        {
            if (SelectedExpense != null && SelectedExpense.frequency != value)
            {
                SelectedExpense.frequency = value;
                NotifyPropertyChanged();
            }
        }
    }

    public ExpenseViewModel()
    {
        // Initialize with a new expense
        SelectedExpense = new Expense();
    }

    public void RefreshExpenses()
    {
        NotifyPropertyChanged(nameof(FamilyMembers));
        NotifyPropertyChanged(nameof(HouseholdBalance));
    }

    public void AddExpense()
    {
        if (SelectedExpenseMember != null && !string.IsNullOrWhiteSpace(Name) && Amount > 0)
        {
            ExpenseService.AddExpense(
                SelectedExpenseMember.id, 
                Name, 
                Amount, 
                Month, 
                Year, 
                Day, 
                Category ?? string.Empty, 
                Description ?? string.Empty, 
                Recurring, 
                Frequency ?? string.Empty);

            // Clear the form by creating a new expense
            SelectedExpense = new Expense();
            SelectedExpenseMember = null;
            RefreshExpenses();
        }
    }

    public void RemoveExpense(Expense? expense)
    {
        if (expense?.id != null)
        {
            ExpenseService.RemoveExpense(expense.id.Value);
            RefreshExpenses();
        }
    }
}