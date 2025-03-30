public class Video 
{
    public string _title;
    public string _author; 
    public string _length;
    public List<Comment> _comments = new List<Comment>();

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine($"Number of Comments: {_comments.Count}");

        foreach (Comment comment in _comments)
        {
            comment.DisplayComments();
            Console.WriteLine("---------------------------------------------------------");
        }

    }
}