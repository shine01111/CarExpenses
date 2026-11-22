namespace CarExpenses;

public class FuelExpense : CarExpense
{
    public double Liters { get; }
    public string FuelBrand { get; }

    public override string CategoryName => "Заправка";

    public FuelExpense(DateOnly date, decimal amount, int mileageKm, string description, double liters, string fuelBrand)
        : base(date, amount, mileageKm, description)
    {
        if (liters <= 0)
            throw new ArgumentOutOfRangeException(nameof(liters), "Кількість літрів має бути більшою за 0.");

        if (string.IsNullOrWhiteSpace(fuelBrand))
            throw new ArgumentException("Марка пального не може бути порожньою.", nameof(fuelBrand));

        Liters = liters;
        FuelBrand = fuelBrand.Trim();
    }

    public decimal CalculatePricePerLiter() =>
        Math.Round(Amount / (decimal)Liters, 2);

    public override string GetDetails() =>
        $"{FuelBrand}, {Liters:F1} л по {CalculatePricePerLiter():F2} грн/л";
}