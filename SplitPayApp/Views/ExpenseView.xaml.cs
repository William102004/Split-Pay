
namespace SplitPayApp.Views;
using SplitPayApp.ViewModels;
using Split_Play_Libraries.Models;
using Split_Pay_Libraries.Models;
using SplitPayApp.Views;
public partial class ExpenseView : ContentView
{
	public ExpenseView()
	{
		InitializeComponent();
		BindingContext = new ExpenseViewModel();
		

	}

	private void AddExpenseClicked(object sender, EventArgs e)
	{
		(BindingContext as ExpenseViewModel)?.AddExpense();
		(BindingContext as ExpenseViewModel)?.RefreshExpenses();


	}

	private void RemoveExpenseClicked(object sender, EventArgs e)
	{
		if (sender is Button button && button.BindingContext is Expense expense)
		{
			var viewModel = BindingContext as ExpenseViewModel;
			viewModel?.RemoveExpense(expense);
		}
	}

	public void RefreshView()
    {
        (BindingContext as ExpenseViewModel)?.RefreshExpenses();
    }
}