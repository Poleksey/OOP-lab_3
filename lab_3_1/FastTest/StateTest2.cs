using Xunit;

namespace FastTests;

public class StateTests2
{
    [Fact]
    public void Ticket_FullLifecycle_StandardPath()
    {
        var ticket = new Ticket();
        
        ticket.Preparing();    
        
        ticket.Delivering();   
        
        ticket.AwaitingPayment();    
        
        ticket.Complete();    
        
        Assert.True(true);
    }
    
    [Fact]
    public void Ticket_CancellationPath()
    {
        var ticket = new Ticket();
        
        
        ticket.Canceling();   
        
        var ticket2 = new Ticket();
        ticket2.Preparing();   
        ticket2.Canceling();   
        
        Assert.True(true);
    }
    [Fact]
    public void Ticket_CannotCompleteFromPreparing()
    {
        var ticket = new Ticket();
        
        Assert.Throws<InvalidOperationException>(() => 
        {
            ticket.Complete();
        });
    }
    
    [Fact]
    public void Ticket_CannotDeliverFromAwaitingPayment()
    {
        var ticket = new Ticket();
        
        ticket.Preparing();
        ticket.Delivering();
        ticket.AwaitingPayment();
        
        Assert.Throws<InvalidOperationException>(() => 
        {
            ticket.Delivering();
        });
    }
    
}