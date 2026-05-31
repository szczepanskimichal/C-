namespace DiscountRefactor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
}

namespace DiscountRefactor
{
    public class DiscountApplicationService
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;
        private readonly ICartRepository _cartRepository;

        public DiscountApplicationService(
            IDiscountCodeRepository discountCodeRepository,
            ICartRepository cartRepository)
        {
            _discountCodeRepository = discountCodeRepository;
            _cartRepository = cartRepository;
        }

        public async Task<string> ApplyDiscountCodeAsync(Guid cartId, string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "Discount code is required.";
            }

            code = code.Trim().ToUpper();

            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                return "Cart not found.";
            }

            var discountCode = await _discountCodeRepository.GetByCodeAsync(code);
            if (discountCode == null)
            {
                return "Discount code does not exist.";
            }

            //if (discountCode.ExpiresAt < DateTime.UtcNow)
            //{
            //    return "Discount code has expired.";
            //}

            if (discountCode.IsUsed)
            {
                return "Discount code has already been used.";
            }

            if (cart.TotalAmount < discountCode.MinimumAmount)
            {
                return "Cart total is too low for this discount code.";
            }

            var discountAmount = 0m;

            if (discountCode.PercentOff.HasValue)
            {
                discountAmount = cart.TotalAmount * discountCode.PercentOff.Value / 100m;
            }
            else if (discountCode.AmountOff.HasValue)
            {
                discountAmount = discountCode.AmountOff.Value;
            }

            if (discountAmount > cart.TotalAmount)
            {
                discountAmount = cart.TotalAmount;
            }

            cart.TotalAmount -= discountAmount;
            cart.AppliedDiscountCode = code;
            discountCode.IsUsed = true;

            await _cartRepository.SaveAsync(cart);
            await _discountCodeRepository.SaveAsync(discountCode);

            return "Discount code applied.";
        }
    }

    public interface IDiscountCodeRepository
    {
        Task<DiscountCode?> GetByCodeAsync(string code);
        Task SaveAsync(DiscountCode discountCode);
    }

    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(Guid id);
        Task SaveAsync(Cart cart);
    }

    public class Cart
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string? AppliedDiscountCode { get; set; }
    }

    public class DiscountCode
    {
        public string Code { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal? PercentOff { get; set; }
        public decimal? AmountOff { get; set; }
    }

    
}