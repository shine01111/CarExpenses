namespace CarExpenses;

public class FineExpense : CarExpense
{
    public string ViolationArticle { get; }
    public bool PaidWithDiscount { get; }

    public override string CategoryName => "Штраф";

    public FineExpense(DateOnly date, decimal amount, int mileageKm, string description, string violationArticle, bool paidWithDiscount)
        : base(date, amount, mileageKm, description)
    {
        if (string.IsNullOrWhiteSpace(violationArticle))
            throw new ArgumentException("Стаття порушення не може бути порожньою.", nameof(violationArticle));

        ViolationArticle = violationArticle.Trim();
        PaidWithDiscount = paidWithDiscount;
    }

    public override string GetDetails() =>
        $"ст. {ViolationArticle}, {(PaidWithDiscount ? "сплачено зі знижкою 50%" : "повна оплата")}";
}