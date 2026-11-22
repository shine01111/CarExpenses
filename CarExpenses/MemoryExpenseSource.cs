namespace CarExpenses;

public class MemoryExpenseSource : IExpenseSource
{
    public IEnumerable<CarExpense> LoadExpenses() =>
    [
        new FuelExpense(new DateOnly(2026, 10, 15), 2250.00m, 124500, "Заправка на трасі", 40.0, "А-95 Євро"),
        new MaintenanceExpense(new DateOnly(2026, 10, 22), 3400.00m, 124850, "Заміна мастила та фільтрів", "АвтоСервіс Плюс", 10000),
        new FineExpense(new DateOnly(2026, 11, 03), 340.00m, 125120, "Паркування у забороненому місці", "122 ч.1 КУпАП", true),
        new FuelExpense(new DateOnly(2026, 11, 18), 1980.50m, 125600, "Заправка у місті", 35.0, "А-95 Pulls"),
        new MaintenanceExpense(new DateOnly(2026, 11, 21), 1650.00m, 125750, "Діагностика ходової частини", "Bosch Car Service", 5000)
    ];
}