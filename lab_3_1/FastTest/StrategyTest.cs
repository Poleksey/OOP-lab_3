using Xunit;

namespace FastTests;

public class StrategyTests
{
    [Fact]
    public void BirthdayStrategy_Applies200Discount()
    {
        var ticket = new Ticket();
        ticket.Items.Add(new Dish { Price = 1000 });
        ticket.AddOrderStrategy(new BirthdayStrategy());
        
        var total = ticket.CalculateTotal();
        var expected = (1000 - 200) * 1.22m; 
        
        Assert.Equal(expected, total);
    }
    
    [Fact]
    public void LoyaltyStrategy_Applies50Discount()
    {
        var ticket = new Ticket();
        ticket.Items.Add(new Dish { Price = 1000 });
        ticket.AddOrderStrategy(new LoyaltyStrategy());
        
        var total = ticket.CalculateTotal();
        var expected = (1000 - 50) * 1.22m;
        
        Assert.Equal(expected, total);
    }
    
    [Fact]
    public void StandardDeliveryStrategy_Calculates100Fee()
    {
        var ticket = new Ticket
        {
            Customer = new User { Address = "ул. 1" },
            Restaurant = new Restaurant { Location = "ул. 2" }
        };
        
        ticket.SetDeliveryStrategy(new StandardDelivery());
        
        Assert.Equal(100, ticket.DeliveryFee);
        Assert.Equal("Стандартная", ticket.DeliveryStrategy.GetDeliveryType());
    }
    
    [Fact]
    public void FastDeliveryStrategy_Calculates300Fee()
    {
        var ticket = new Ticket
        {
            Customer = new User { Address = "ул. 3" },
            Restaurant = new Restaurant { Location = "ул. 4" }
        };
        
        ticket.SetDeliveryStrategy(new FastDelivery());
        
        Assert.Equal(300, ticket.DeliveryFee);
        Assert.Equal("Срочная", ticket.DeliveryStrategy.GetDeliveryType());
    }
    [Fact]
    public void PutDownTheNapkins_ShouldIncreaseAdditionalFeeProperty()
    {
        var ticket = new Ticket();
        var initialAdditionalFee = ticket.AdditionalFee;
        
        var napkinsStrategy = new PutDownTheNapkins();
        
        napkinsStrategy.Apply(ticket);
        
        Assert.Equal(initialAdditionalFee + 55, ticket.AdditionalFee);
    }
}
    
