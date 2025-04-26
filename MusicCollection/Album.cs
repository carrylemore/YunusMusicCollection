namespace MusicCollection
{
    public class Album
    {
        public required string Title { get; set; }
        public required Artist Artist { get; set; }
        public int Year { get; set; }

        public Album() { }

        public Album(string title, Artist artist, int year)
        {
            Title = title;
            Artist = artist;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Album: {Title}, Artist: {Artist.Name}, Year: {Year}");
        }
    }
}
