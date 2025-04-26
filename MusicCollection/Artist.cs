namespace MusicCollection
{
    public class Artist
    {
        public required string Name { get; set; }

        public Artist() { }

        public Artist(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
