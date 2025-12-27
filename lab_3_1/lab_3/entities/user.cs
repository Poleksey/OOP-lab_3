public class User
{
    private static int UserIdCount = 1;
    public int UserId {get; set;} = UserIdCount++;  
    public string Name {get; set;}
    public string Address {get; set;}
    public string Phone {get; set;}
}