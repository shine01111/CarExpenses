namespace CarExpenses;

public interface IExpenseSorter
{
    string Title { get; }
    IEnumerable<CarExpense> Sort(IEnumerable<CarExpense> expenses);
}