namespace _1_PipeAndCompose
{
    public record OrderLineInput(
        int ProductId,
        string ProductName,
        int UnitPrice,
        int Quantity);

    public record OrderLine(
        int ProductId,
        string ProductName,
        int UnitPrice,
        int Quantity);

    public record PricedOrderLine(
        int ProductId,
        string ProductName,
        int UnitPrice,
        int Quantity,
        int Total);
}
