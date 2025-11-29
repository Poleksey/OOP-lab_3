public interface ITicketState
{
    void Preparing();
    void Canceling();
    void Delivering();
    void Complete();
}


public class Ticket
{
    private static int TicketIdCount = 1;
    public int TicketId { get; } = TicketIdCount++;  


    public User Customer { get; set; }          
    public List<Dish> Items { get; } = new();   
    public Restaurant Restaurant { get; set; }  


    private ITicketState _state;
    
    public Ticket()
    {
        _state = new PreparingState(); 
    }
    
    public void SetState(ITicketState state) => _state = state;
    
    public void Preparing() => _state.Preparing(this);
    public void Canceling() => _state.Canceling(this);
    public void Delivering() => _state.Delivering(this);
    public void Complete()=> _state.Complete(this);
}



public class PreparingState: ITicketState
{
    private Ticket _ticket;

    public PreparingState(Ticket ticket)
    {
        _ticket = ticket;
    }
    public void Preparing()
    {
        Console.WriteLine("готовится");
    }
    
    public void Canceling() 
    {
    _ticket.SetState(new CanceledState());
    }
    
    public void Delivering()
    {
       _ticket.SetState(new DeliveringState(_ticket));
    }
    
    public void Complete()
    {
        Console.WriteLine("готовится");
    }

}

public class DeliveringState: ITicketState
{
    private Ticket _ticket;

    public DeliveringState(Ticket ticket)
    {
        _ticket = ticket;
    }
    public void Preparing()
    {
          Console.WriteLine("в дороге");
    }
    public void Canceling()
    {
        _ticket.SetState(new CanceledState());
    }

    public void Delivering()
    {
          Console.WriteLine("в дороге");
    }
    
    public void Complete()
    {
        _ticket.SetState(new DeliveredState(_ticket));
    }

}

public class DeliveredState: ITicketState
{
   
    public void Preparing() => Console.WriteLine("Доставлен");
    public void Canceling() => Console.WriteLine("Доставлен");
    public void Delivering() => Console.WriteLine("Доставлен");
    public void Complete() => Console.WriteLine("Доставлен");
}

public class CanceledState : ITicketState
{
    public void Preparing() => Console.WriteLine("Отменен");
    public void Canceling() => Console.WriteLine("Отменен");
    public void Delivering() => Console.WriteLine("Отменен");
    public void Complete() => Console.WriteLine("Отменен");
}