namespace MusicCollection
{
    public class Song : Media
    {
        public required Album Album { get; set; }
        public int Duration { get; set; }

        public Song() : base("Unknown")
        {
            Album = new Album
            {
                Title = "Unknown",
                Artist = new Artist { Name = "Unknown" },
                Year = 0
            };
            Duration = 0;
        }

        public Song(string title, Album album, int duration) : base(title)
        {
            Album = album;
            Duration = duration;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Song Title: {Title}, Album: {Album.Title}, Duration: {Duration} seconds");
        }
    }
}
