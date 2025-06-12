
namespace SplitPayApp.Views;
using SplitPayApp.ViewModels;
using Split_Play_Libraries.Models;
using Split_Pay_Libraries.Models;

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
	}

	private void RemoveExpenseClicked(object sender, EventArgs e)
	{
		if (sender is Button button && button.BindingContext is Expense expense)
		{
			var viewModel = BindingContext as ExpenseViewModel;
			viewModel?.RemoveExpense(expense);
		}
	}

	protected override void OnParentSet()
	{
		base.OnParentSet();
		// Refresh data when the view appears
		(BindingContext as ExpenseViewModel)?.RefreshExpenses();
		(BindingContext as ExpenseViewModel)?.NotifyPropertyChanged(nameof(ExpenseViewModel.FamilyMembers));
	}
}