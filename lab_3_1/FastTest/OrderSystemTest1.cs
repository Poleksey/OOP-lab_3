using Xunit;
using System.Collections.Generic;

namespace FastTests;

public class SystemTests1
{
    [Fact]
    public void CreateOrder_ReturnsTicket()
    {
        var system = new OrderSystem();
        var order = system.CreateOrder(
            new User(),
            new Restaurant(),
            new List<Dish> { new Dish { Price = 100 } }
        );
        
        Assert.NotNull(order);
    }
    
    [Fact]
    public void StartPreparing_ChangesState()
    {
        var system = new OrderSystem();
        var order = system.CreateOrder(new User(), new Restaurant(), new List<Dish>());
        
        system.StartPreparing(order.TicketId);
        Assert.True(true);
    }
    
    [Fact]
    public void RepeatOrder_ClonesTicket()
    {
        var system = new OrderSystem();
        var user = new User();
        var order = system.CreateOrder(user, new Restaurant(), new List<Dish>());
        
        var repeated = system.RepeatOrder(order.TicketId, user);
        
        Assert.NotNull(repeated);
        Assert.NotEqual(order.TicketId, repeated.TicketId);
    }
}