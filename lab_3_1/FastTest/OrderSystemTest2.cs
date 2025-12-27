using Xunit;
using System.Collections.Generic;

namespace FastTests;

public class StrategyThroughSystemTests
{
    [Fact]
    public void OrderSystem_WithLoyaltyStrategy_AppliesDiscount()
    {
        var system = new OrderSystem();
        var user = new User();
        var restaurant = new Restaurant();
        var dishes = new List<Dish> { new Dish { Price = 1000 } };
        
        var loyaltyStrategy = new LoyaltyStrategy();
        var strategies = new List<IOrderStrategy> { loyaltyStrategy };
        
        var order = system.CreateOrder(user, restaurant, dishes, strategies);
        
        var total = order.CalculateTotal();
        var expected = (1000 - 50) * 1.22m;
        
        Assert.Equal(expected, total);
    }
}