using CarExpenses;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var expenses = new List<CarExpense>
{
    new FuelExpense(new DateOnly(2026, 10, 15), 2250.00m, 124500, "Заправка на трасі", 40.0, "А-95 Євро"),
    new MaintenanceExpense(new DateOnly(2026, 10, 22), 3400.00m, 124850, "Заміна мастила та фільтрів", "АвтоСервіс Плюс", 10000),
    new FineExpense(new DateOnly(2026, 11, 03), 340.00m, 125120, "Паркування у забороненому місці", "122 ч.1 КУпАП", true),
    new FuelExpense(new DateOnly(2026, 11, 18), 1980.50m, 125600, "Заправка у місті", 35.0, "А-95 Pulls"),
    new MaintenanceExpense(new DateOnly(2026, 11, 21), 1650.00m, 125750, "Діагностика ходової частини", "Bosch Car Service", 5000)
};

Console.WriteLine("=== Облік витрат на автомобіль (поліморфний список) ===\n");

foreach (var expense in expenses)
{
    Console.WriteLine(expense);
}

var summary = ExpenseSummary.FromExpenses(expenses);

Console.WriteLine("\n=== Зведена статистика (структура ExpenseSummary) ===");
Console.WriteLine($"Всього записів: {summary.TotalCount}");
Console.WriteLine($"Загальна сума витрат: {summary.TotalAmount:F2} грн");
Console.WriteLine($"Середній чек: {summary.AverageExpense:F2} грн");
Console.WriteLine($"  • Заправки: {summary.FuelTotal:F2} грн (всього {summary.TotalLiters:F1} л)");
Console.WriteLine($"  • Обслуговування: {summary.MaintenanceTotal:F2} грн");
Console.WriteLine($"  • Штрафи: {summary.FineTotal:F2} грн");