namespace MusicCollection
{
    public abstract class Media
    {
        public required string Title { get; set; }

        public Media(string title)
        {
            Title = title;
        }

        public abstract void DisplayInfo();
    }
}
