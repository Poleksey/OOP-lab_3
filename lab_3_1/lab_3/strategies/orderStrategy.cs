public interface IOrderStrategy
{
    decimal Apply(Ticket ticket); // всякое особое поведение влияет на итоговую стоимость
    string GetDescription();
}