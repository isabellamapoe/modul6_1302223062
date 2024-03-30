class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string Username)
    {
        this.Username = Username;
        Random random = new Random();
        id = random.Next(10000, 99999);
        uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            total += uploadedVideos.ElementAt(i).GetPlayCount();
        }
        return total;
    }
    public void addVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine("video " + (i + 1) + " judul : " + uploadedVideos[i].GetTitle());
        }
    }
}


class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (!string.IsNullOrEmpty(title) && title.Length <= 100)
        {
            this.title = title;
            this.id = GenerateRandomId();
            playCount = 0;
        }
    }

    private int GenerateRandomId()
    {
        Random random = new Random();
        return random.Next(10000, 99999);
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentOutOfRangeException("Input harus di antara 0 dan 10.000.000.");
        }
        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video Details:\nID: {id}\nTitle: {title}\nPlay Count: {playCount}");
    }
    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user1 = new SayaTubeUser("bella");

        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Inventing Anna oleh Bella");
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film Avatar oleh Bella");
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film avengers oleh Bella");
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film starwars  oleh Bella");
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film Anna oleh Bella");
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film madame web Anna oleh Bella");
        SayaTubeVideo video7 = new SayaTubeVideo("Review Film barbie Anna oleh Bella");
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film anyone but you Anna oleh Bella");
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film thor Anna oleh Bella");
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film blackwidow Anna oleh Bella");

        user1.addVideo(video1);
        user1.addVideo(video2);
        user1.addVideo(video3);
        user1.addVideo(video4);
        user1.addVideo(video5);
        user1.addVideo(video6);
        user1.addVideo(video7);
        user1.addVideo(video8);
        user1.addVideo(video9);
        user1.addVideo(video10);

        user1.PrintAllVideoPlaycount();
        video1.PrintVideoDetails();
    }
}
