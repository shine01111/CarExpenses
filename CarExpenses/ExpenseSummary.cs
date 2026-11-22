namespace CarExpenses;

public readonly record struct ExpenseSummary(
    int TotalCount,
    decimal TotalAmount,
    decimal FuelTotal,
    decimal MaintenanceTotal,
    decimal FineTotal,
    double TotalLiters)
{
    public decimal AverageExpense =>
        TotalCount > 0 ? Math.Round(TotalAmount / TotalCount, 2) : 0m;

    public static ExpenseSummary FromExpenses(IEnumerable<CarExpense> expenses)
    {
        int count = 0;
        decimal total = 0m, fuel = 0m, maintenance = 0m, fine = 0m;
        double liters = 0;

        foreach (var item in expenses)
        {
            count++;
            total += item.Amount;

            switch (item)
            {
                case FuelExpense f:
                    fuel += f.Amount;
                    liters += f.Liters;
                    break;
                case MaintenanceExpense m:
                    maintenance += m.Amount;
                    break;
                case FineExpense fn:
                    fine += fn.Amount;
                    break;
            }
        }

        return new ExpenseSummary(count, total, fuel, maintenance, fine, liters);
    }
}