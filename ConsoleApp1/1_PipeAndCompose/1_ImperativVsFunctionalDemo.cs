using System.Text.Json;

namespace _1_PipeAndCompose
{
    internal class ImperativVsFunctionalDemo
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


            // imperativ versjon
            var input = ParseOrderLine(json);
            var validated = ValidateInput(input);
            var orderLine = CreateOrderLine(validated);
            var priced = CalculateTotal(orderLine);
            var outputI = FormatOrderLine(priced);
            Console.WriteLine(outputI);

            // funksjonell versjon med pipe
            var outputF = Utils.Pipe(json,
                ParseOrderLine, ValidateInput, CreateOrderLine, CalculateTotal, FormatOrderLine);
            Console.WriteLine(outputF);
        }

        static OrderLineInput ParseOrderLine(string json)
        {
            return JsonSerializer.Deserialize<OrderLineInput>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }

        static OrderLineInput ValidateInput(OrderLineInput input)
        {
            // Happy path nå: vi later som alt er gyldig.
            // Senere kan denne returnere Result<OrderLineInput>.
            return input;
        }

        static OrderLine CreateOrderLine(OrderLineInput input)
        {
            return new OrderLine(
                ProductId: input.ProductId,
                ProductName: input.ProductName.Trim(),
                UnitPrice: input.UnitPrice,
                Quantity: input.Quantity);
        }

        static PricedOrderLine CalculateTotal(OrderLine orderLine)
        {
            return new PricedOrderLine(
                ProductId: orderLine.ProductId,
                ProductName: orderLine.ProductName,
                UnitPrice: orderLine.UnitPrice,
                Quantity: orderLine.Quantity,
                Total: orderLine.UnitPrice * orderLine.Quantity);
        }

        static string FormatOrderLine(PricedOrderLine line)
        {
            return $"{line.Quantity} x {line.ProductName} = {line.Total}";
        }
    }
}
