namespace DiscountRefactor
{
    public class DiscountCode
    {
        public string Code { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal? PercentOff { get; set; }
        public decimal? AmountOff { get; set; }

        public DiscountCode(string code, DateTime expiresAt, bool isUsed, decimal minimumAmount, decimal? percentOff, decimal? amountOff)
        {
            Code = code;
            ExpiresAt = expiresAt;
            IsUsed = isUsed;
            MinimumAmount = minimumAmount;
            PercentOff = percentOff;
            AmountOff = amountOff;

            if (ExpiresAt < DateTime.UtcNow)
            {
                throw new ArgumentException("Discount code has expired.");
            }

            if (IsUsed)
            {
                throw new ArgumentException("Discount code has already been used.");
            }
        }
    }
}
