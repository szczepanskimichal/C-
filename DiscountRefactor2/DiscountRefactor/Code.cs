using System;
using System.Collections.Generic;
using System.Text;

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

            //if (discountCode.IsUsed)
            //{
            //    return "Discount code has already been used.";
            //}

            //if (cart.TotalAmount < discountCode.MinimumAmount)
            //{
            //    return "Cart total is too low for this discount code.";
            //}

            cart.ApplyDiscountCode(discountCode);
            var discountAmount = cart.CalculateDiscountAmount();

            cart.TotalAmount -= discountAmount;
            //cart.AppliedDiscountCode = code;
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
}
