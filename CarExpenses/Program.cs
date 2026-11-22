using CarExpenses;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var tracker = new ExpenseTracker(new MemoryExpenseSource(), new SortByDate());

Console.WriteLine($"=== Сортування: {tracker.Sorter.Title} ===\n");
foreach (var item in tracker.GetSortedExpenses())
{
    Console.WriteLine(item);
}

tracker.Sorter = new SortByAmountDesc();
Console.WriteLine($"\n=== Сортування: {tracker.Sorter.Title} ===\n");
foreach (var item in tracker.GetSortedExpenses())
{
    Console.WriteLine(item);
}

Console.WriteLine("\n=== Перевірка валідації ===");
try
{
    var invalidExpense = new FuelExpense(new DateOnly(2026, 11, 22), -500m, 125800, "Помилковий чек", 10, "А-95");
    tracker.AddExpense(invalidExpense);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Перехоплено помилку введення: {ex.Message}");
}

var summary = tracker.GetSummary();
Console.WriteLine($"\nРазом: {summary.TotalCount} записів на суму {summary.TotalAmount:F2} грн (середній чек: {summary.AverageExpense:F2} грн).");