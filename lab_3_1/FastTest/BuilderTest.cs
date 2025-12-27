using Xunit;

namespace FastTests;

public class BuilderTests
{
    [Fact]
    public void OrderBuilder_CreatesTicket_WithCustomer()
    {
        var builder = new OrderBuilder();
        builder.SetCustomer(new User { UserId = 1, Name = "Test" });
        var ticket = builder.GetResult();
        
        Assert.NotNull(ticket);
        Assert.NotNull(ticket.Customer);
    }
    
    [Fact]
    public void OrderBuilder_BuildsCompleteOrder()
    {
        var builder = new OrderBuilder();
        builder.SetCustomer(new User { UserId = 1, Name = "Пользователь-1" });
        builder.SetRestaurant(new Restaurant { Name = "Ресторан-хлеб" });
        builder.AddDish(new Dish { Name = "хлеб", Price = 500 });
        builder.AddOrderStrategy(new BirthdayStrategy());
        
        var ticket = builder.GetResult();
        
        Assert.NotNull(ticket.Restaurant);
        Assert.Single(ticket.Items);
    }
}