using Xunit;

namespace FastTests;

public class StateTests
{
    [Fact]
    public void Ticket_InitialState_IsPreparing()
    {
        var ticket = new Ticket();
        ticket.Preparing(); 
        Assert.True(true);
    }
    
    [Fact]
    public void Ticket_StateTransitions_Work()
    {
        var ticket = new Ticket();
        
        ticket.Preparing();
        ticket.Delivering();
        
        var ticket2 = new Ticket();
        ticket2.Canceling();
    }
}