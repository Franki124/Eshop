using Eshop.Domain.Orders.Events;
using Eshop.Domain.Orders.Rules;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public List<OrderProduct> Products { get; private set; }



        private Order(Guid customerId, List<OrderProduct> orderProducts)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

            AddDomainEvent(new OrderAddedEvent(Id, customerId));
        }

        public static Order Create(
            Guid customerId,
            List<OrderProductData> orderProductsData,
            List<ProductPriceData> allProductPriceDatas,
            decimal orderCostLimit = 15000)

        {
            List<OrderProduct> orderProducts = new();

            foreach (var orderProductData in orderProductsData)
            {
                var productPriceData = allProductPriceDatas.First(x => x.ProductId == orderProductData.ProductId);

                var orderProduct = OrderProduct.Create(orderProductData.ProductId, orderProductData.Quantity, productPriceData.UnitPrice);

                orderProducts.Add(orderProduct);
            }

            CheckRule(new OrderMustHaveAtLeastOneProductRule(orderProducts));

            var totalCost = orderProducts.Sum(op => op.TotalCost);
            CheckRule(new OrderTotalCostMustNotExceedLimitRule(totalCost, orderCostLimit));

            return new Order(customerId, orderProducts);
        }
    }
}
