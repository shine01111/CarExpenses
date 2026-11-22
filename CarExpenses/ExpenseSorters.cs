namespace CarExpenses;

public class SortByDate : IExpenseSorter
{
    public string Title => "За датою (від старіших до новіших)";

    public IEnumerable<CarExpense> Sort(IEnumerable<CarExpense> expenses) =>
        expenses.OrderBy(e => e.Date);
}

public class SortByAmountDesc : IExpenseSorter
{
    public string Title => "За сумою (від найбільших витрат)";

    public IEnumerable<CarExpense> Sort(IEnumerable<CarExpense> expenses) =>
        expenses.OrderByDescending(e => e.Amount);
}