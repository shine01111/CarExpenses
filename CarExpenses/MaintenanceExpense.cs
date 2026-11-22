namespace CarExpenses;

public class MaintenanceExpense : CarExpense
{
    public string ServiceStation { get; }
    public int WarrantyKm { get; }

    public override string CategoryName => "Обслуговування";

    public MaintenanceExpense(DateOnly date, decimal amount, int mileageKm, string description, string serviceStation, int warrantyKm)
        : base(date, amount, mileageKm, description)
    {
        if (string.IsNullOrWhiteSpace(serviceStation))
            throw new ArgumentException("Назва СТО не може бути порожньою.", nameof(serviceStation));

        if (warrantyKm < 0)
            throw new ArgumentOutOfRangeException(nameof(warrantyKm), "Гарантійний пробіг не може бути від'ємним.");

        ServiceStation = serviceStation.Trim();
        WarrantyKm = warrantyKm;
    }

    public override string GetDetails() =>
        $"СТО «{ServiceStation}», гарантія {WarrantyKm} км";
}