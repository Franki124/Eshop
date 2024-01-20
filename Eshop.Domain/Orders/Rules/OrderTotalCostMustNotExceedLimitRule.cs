using Eshop.Domain.SeedWork;

public class OrderTotalCostMustNotExceedLimitRule : IBusinessRule
{
    private readonly decimal _totalCost;
    private readonly decimal _limit;

    public OrderTotalCostMustNotExceedLimitRule(decimal totalCost, decimal limit)
    {
        _totalCost = totalCost;
        _limit = limit;
    }

    public bool IsBroken() => _totalCost > _limit;

    public string Message => $"Order total cost exceeds the limit of {_limit}.";
}