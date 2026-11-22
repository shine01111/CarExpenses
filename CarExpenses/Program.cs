using CarExpenses;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var typeNames = new Dictionary<ExpenseType, string>
{
    [ExpenseType.Fuel] = "Заправка",
    [ExpenseType.Maintenance] = "Обслуговування",
    [ExpenseType.Fine] = "Штраф"
};

var expenses = new List<CarExpense>
{
    new CarExpense(new DateOnly(2026, 10, 15), ExpenseType.Fuel, 2250.00m, 124500, "Бензин А-95 (40 л)"),
    new CarExpense(new DateOnly(2026, 10, 22), ExpenseType.Maintenance, 3400.00m, 124850, "Заміна мастила та фільтрів"),
    new CarExpense(new DateOnly(2026, 11, 03), ExpenseType.Fine, 340.00m, 125120, "Штраф за паркування у недозволеному місці"),
    new CarExpense(new DateOnly(2026, 11, 18), ExpenseType.Fuel, 1980.50m, 125600, "Бензин А-95 (35 л)")
};

Console.WriteLine("=== Облік витрат на автомобіль ===\n");

decimal total = 0;
foreach (var item in expenses)
{
    total += item.Amount;
    Console.WriteLine($"{item.Date:yyyy-MM-dd} | {typeNames[item.Type]} | {item.Description} — {item.Amount:F2} грн (пробіг: {item.MileageKm} км)");
}

Console.WriteLine("\n-------------------------------------------------------");
Console.WriteLine($"Всього записів: {expenses.Count}");
Console.WriteLine($"Загальна сума витрат: {total:F2} грн");