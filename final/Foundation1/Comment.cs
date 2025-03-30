public class Comment 
{
    public string _username;
    public string _comment;

    public void DisplayComments()
    {
        Console.WriteLine($"Username - {_username}");
        Console.WriteLine($"Comment: {_comment}");
    }
}