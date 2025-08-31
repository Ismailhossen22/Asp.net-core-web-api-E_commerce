using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Dto;

using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Bigbasket_Ecommerce.Services
{
    public class CardServices : ICardServices
    {
        private readonly ICardItemRepository _CardReop;
        private readonly IRepository<Order> _OrderReop;
        private readonly IRepository<OrderItem> _OrderItemRep;
        private readonly IRepository<Payment> _PaymentRep;

        private AppDbContext _Context;

        public CardServices(ICardItemRepository cardReop, IRepository<Order> orderReop,
            AppDbContext context, IRepository<OrderItem> orderItemRep, IRepository<Payment> paymentRep)
        {
            _CardReop = cardReop ?? throw new ArgumentNullException(nameof(cardReop));
            _OrderReop = orderReop ?? throw new ArgumentNullException(nameof(orderReop));
            _Context = context ?? throw new ArgumentNullException(nameof(context));
            _OrderItemRep = orderItemRep;
            _PaymentRep = paymentRep;
        }


        public async Task AddToCart([FromBody] CardItemDto dto)
        {
            var existing = await _CardReop.GetCartItem(dto.CustomerId, dto.ProductId);
            if(existing != null)
            {
                existing.Quantity += dto.Quantity;
                _CardReop.Update(existing);

            }
            else
            {
                await _CardReop.AddAsync(new CartItem
                {
                    UserId=dto.CustomerId,
                    ProductId=dto.ProductId,
                    Quantity=dto.Quantity,
                    Price=dto.Price,
                    

                });

                await _CardReop.SaveChangesAsync();
            }



        }

        public async Task<CheckoutPreviewDto> CheckoutPreview(int customerId)
        {

            var items = await _CardReop.GetCartByCustomerId(customerId);

            if (!items.Any())
            {
                throw new Exception("Cart is empty");
            }

            return CalculateCheckout(customerId, items);
           

           
        }



        public async Task<OrderDto> Checkout(int customerId)
        {    // Step 1: Cart থেকে সব item বের করা
            var cartItems = await _CardReop.GetCartByCustomerId(customerId);
            if (!cartItems.Any())
            {
                throw new Exception("Cart is empty");

            }
            // Step 3: নতুন Order তৈরি করা
            using var Transaction = await _Context.Database.BeginTransactionAsync();
            var preview = CalculateCheckout(customerId, cartItems);

            var order = new Order
            {
                UserId = customerId,
                OrderDate = DateTime.Now,
                SubTotal=preview.SubTotal,
                Discount = preview.Discound,
                ShippingCost=preview.Shipping,
                TaxAmount=preview.Tax,
                TotalAmount = preview.TotalAmount,
                 OrderStatus = "confirmed",

            };
            await _OrderReop.AddAsync(order);
            await _OrderReop.SaveChangesAsync();

             foreach(var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId=order.OrderId,
                    ProductId=item.ProductId,
                    Quantity=item.Quantity,
                    UnitPrice=item.Price,
                    TotalPrice=item.Quantity*item.Price,

                };
                await _OrderItemRep.AddAsync(orderItem);

            }
            await _OrderItemRep.SaveChangesAsync();



            // Clear cart after checkout
            foreach(var item in cartItems)
            {
                _CardReop.Remove(item);
            }
            await _CardReop.SaveChangesAsync();
            await Transaction.CommitAsync();

            // Step 6: DTO বানিয়ে return করা
            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.UserId,
                OrderDate = order.OrderDate,
                SubTotal=order.SubTotal,
                Discount=order.Discount,
                ShippingCost=order.ShippingCost,
                Tax=order.TaxAmount,

                TotalAmount=order.TotalAmount,
               
                Items=preview.CartItems

            };
            




        }

      

        private CheckoutPreviewDto CalculateCheckout(int customerId,IEnumerable<CartItem> cartItems)
        {
            double subtotal = cartItems.Sum(c => c.Price * c.Quantity);
            double discount = subtotal > 500 ? 50 : 0;
            double shipping = 40;
            double tax = subtotal * 0.05;
            double total = subtotal - discount + shipping + tax;

            return new CheckoutPreviewDto
            {
                CustomerId = customerId,
                CartItems=cartItems.Select(c=> new CardItemDto
                {
                    CustomerId=c.UserId ,
                    ProductId=c.ProductId,
                    Quantity=c.Quantity,
                    Price=c.Price

                } ).ToList(),
                SubTotal=subtotal,
                Discound=discount,
                Shipping=shipping,
                Tax=tax,
                TotalAmount = total


            };

        }


        public async Task<bool>MakePayment(PaymentDto dto)
        {
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                Amount = dto.Amount,
                Method = dto.Method,
                PaymentDate = DateTime.Now,
                Status = "Paid"
            };


            await _PaymentRep.AddAsync(payment);
            await _PaymentRep.SaveChangesAsync();
            return true;
        }




    }
}
