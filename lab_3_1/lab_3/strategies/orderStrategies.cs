public class PutDownTheNapkins : IOrderStrategy
{
   
    public decimal Apply(Ticket ticket)
    {
        decimal additionalFee = 55;
        ticket.AdditionalFee += additionalFee;
        return ticket.CalculateTotal();
    }
    
    
    public string GetDescription() => "Без скидок";
}


public class LoyaltyStrategy : IOrderStrategy
{
    
    
    public decimal Apply(Ticket ticket)
    {
        decimal discount = 50;
        ticket.DiscountValue += discount;
        return ticket.CalculateTotal();
    }
    
    public string GetDescription() => "Скидка лояльности";
}

//стратегия "по умолчанию"
public class NoDiscountStrategy : IOrderStrategy
{
   
    public decimal Apply(Ticket ticket)
    {
        decimal discount = 0;
        ticket.DiscountValue += discount;
        return ticket.CalculateTotal();
    }
    
    
    public string GetDescription() => "Без скидок";
}

public class BirthdayStrategy : IOrderStrategy
{
    public decimal Apply(Ticket ticket)
    {
        ticket.DiscountValue += 200;
        return ticket.CalculateTotal();
    }
    
    public string GetDescription() => "Скидка на день рождения - 4 хлеба";
}



