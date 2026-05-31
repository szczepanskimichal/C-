namespace DiscountRefactor
{
    public class Cart
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DiscountCode? AppliedDiscountCode { get; set; }

        public Cart(Guid id, decimal totalAmount)
        {
            Id = id;
            TotalAmount = totalAmount;
        }

        public void ApplyDiscountCode(DiscountCode discountCode)
        {
            if (TotalAmount < discountCode.MinimumAmount)
            {
                throw new ArgumentException("Cart total is too low for this discount code.");
            }

            AppliedDiscountCode = discountCode;
        }

        public decimal CalculateDiscountAmount()
        {
            var discountAmount = 0m;

            if (AppliedDiscountCode.PercentOff.HasValue)
            {
                discountAmount = TotalAmount * AppliedDiscountCode.PercentOff.Value / 100m;
            }
            else if (AppliedDiscountCode.AmountOff.HasValue)
            {
                discountAmount = AppliedDiscountCode.AmountOff.Value;
            }

            if (discountAmount > TotalAmount)
            {
                discountAmount = TotalAmount;
            }

            return discountAmount;
        }
    }
}
