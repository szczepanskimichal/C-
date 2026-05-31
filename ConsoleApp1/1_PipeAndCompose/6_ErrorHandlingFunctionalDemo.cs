using System.Text.Json;

namespace _1_PipeAndCompose
{
    internal class ErrorHandlingFunctionalDemo
    {
        public static void Run()
        {
            var json = """
                       {
                           "productId": 10,
                           "productName": "Coffee",
                           "unitPrice": 39,
                           "quantity": 3
                       }
                       """;


            // funksjonell versjon
            var output = Result<string>.Success(json)
                .FlatMap(ParseOrderLine)
                .FlatMap(ValidateInput)
                .Map(CreateOrderLine)
                .FlatMap(CalculateTotal)
                .Map(FormatOrderLine);
            Console.WriteLine(output);

        }

        static Result<OrderLineInput> ParseOrderLine(string json)
        {
            try
            {
                var input = JsonSerializer.Deserialize<OrderLineInput>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return input is null
                    ? Result<OrderLineInput>.Failure("Invalid JSON.")
                    : Result<OrderLineInput>.Success(input);
            }
            catch
            {
                return Result<OrderLineInput>
                    .Failure("Could not parse JSON.");
            }
        }

        static Result<OrderLineInput> ValidateInput(
            OrderLineInput input)
        {
            if (input.Quantity <= 0)
            {
                return Result<OrderLineInput>
                    .Failure("Quantity must be positive.");
            }

            if (input.UnitPrice <= 0)
            {
                return Result<OrderLineInput>
                    .Failure("Unit price must be positive.");
            }

            return Result<OrderLineInput>
                .Success(input);
        }

        static Result<PricedOrderLine> CalculateTotal(OrderLine orderLine)
        {
            try
            {
                var total = checked(
                    orderLine.UnitPrice * orderLine.Quantity);

                return Result<PricedOrderLine>
                    .Success(
                        new PricedOrderLine(
                            ProductId: orderLine.ProductId,
                            ProductName: orderLine.ProductName,
                            UnitPrice: orderLine.UnitPrice,
                            Quantity: orderLine.Quantity,
                            Total: total));
            }
            catch (OverflowException)
            {
                return Result<PricedOrderLine>
                    .Failure("Total overflow.");
            }
        }

        static OrderLine CreateOrderLine(OrderLineInput input)
        {
            return new OrderLine(
                ProductId: input.ProductId,
                ProductName: input.ProductName.Trim(),
                UnitPrice: input.UnitPrice,
                Quantity: input.Quantity);
        }

        static string FormatOrderLine(PricedOrderLine line)
        {
            return $"{line.Quantity} x {line.ProductName} = {line.Total}";
        }

    }
}
