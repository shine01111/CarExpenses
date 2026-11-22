namespace CarExpenses;

public abstract class CarExpense
{
    public DateOnly Date { get; }
    public decimal Amount { get; }
    public int MileageKm { get; }
    public string Description { get; }

    public abstract string CategoryName { get; }

    protected CarExpense(DateOnly date, decimal amount, int mileageKm, string description)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Сума витрати має бути більшою за 0.");

        if (mileageKm < 0)
            throw new ArgumentOutOfRangeException(nameof(mileageKm), "Пробіг не може бути від'ємним.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Опис витрати не може бути порожнім.", nameof(description));

        Date = date;
        Amount = amount;
        MileageKm = mileageKm;
        Description = description.Trim();
    }

    public abstract string GetDetails();

    public override string ToString() =>
        $"{Date:yyyy-MM-dd} | {CategoryName} | {Description} ({GetDetails()}) — {Amount:F2} грн [пробіг: {MileageKm} км]";
}