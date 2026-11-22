namespace CarExpenses;

public interface IExpenseSource
{
    IEnumerable<CarExpense> LoadExpenses();
}