namespace SplitPayApp.Views;
using SplitPayApp.ViewModels;
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
		(BindingContext as ExpenseViewModel)?.RemoveExpense();
		(BindingContext as ExpenseViewModel)?.RefreshExpenses();
    }
}