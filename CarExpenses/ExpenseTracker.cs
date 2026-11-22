namespace CarExpenses;

public class ExpenseTracker
{
    private readonly List<CarExpense> _expenses;
    public IExpenseSorter Sorter { get; set; }

    public ExpenseTracker(IExpenseSource source, IExpenseSorter sorter)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(sorter);

        _expenses = source.LoadExpenses().ToList();
        Sorter = sorter;
    }

    public void AddExpense(CarExpense expense)
    {
        ArgumentNullException.ThrowIfNull(expense);
        _expenses.Add(expense);
    }

    public IReadOnlyList<CarExpense> GetSortedExpenses() =>
        Sorter.Sort(_expenses).ToList();

    public ExpenseSummary GetSummary() =>
        ExpenseSummary.FromExpenses(_expenses);
}