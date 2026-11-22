namespace CarExpenses;

public class CarExpense
{
    public DateOnly Date { get; }
    public ExpenseType Type { get; }
    public decimal Amount { get; }
    public int MileageKm { get; }
    public string Description { get; }

    public CarExpense(DateOnly date, ExpenseType type, decimal amount, int mileageKm, string description)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Сума витрат має бути більшою за 0.");

        if (mileageKm < 0)
            throw new ArgumentOutOfRangeException(nameof(mileageKm), "Пробіг не може бути від'ємним.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Опис витрати не може бути порожнім.", nameof(description));

        Date = date;
        Type = type;
        Amount = amount;
        MileageKm = mileageKm;
        Description = description.Trim();
    }

    public decimal CalculateCostPerThousandKm() =>
        MileageKm > 0 ? Math.Round(Amount / (MileageKm / 1000m), 2) : 0;

    public override string ToString() =>
        $"{Date:yyyy-MM-dd} | [{Type}] {Description} — {Amount:F2} грн (пробіг: {MileageKm} км)";
}
