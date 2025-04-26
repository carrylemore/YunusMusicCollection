using System;
using System.Collections.Generic;
using MusicCollection;

class Program
{
    static List<Artist> artists = new List<Artist>();
    static List<Album> albums = new List<Album>();
    static List<Song> songs = new List<Song>();
    static List<History> histories = new List<History>();

    static void Main(string[] args)
    {
        artists = DataManager.LoadData<Artist>("artists.json");
        albums = DataManager.LoadData<Album>("albums.json");
        songs = DataManager.LoadData<Song>("songs.json");
        histories = DataManager.LoadData<History>("history.json");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Music Collection Management ===");
            Console.WriteLine("1. Add Artist");
            Console.WriteLine("2. Add Album");
            Console.WriteLine("3. Add Song");
            Console.WriteLine("4. View Artists");
            Console.WriteLine("5. View Albums");
            Console.WriteLine("6. View Songs");
            Console.WriteLine("7. View History");
            Console.WriteLine("8. Statistics");
            Console.WriteLine("9. Delete Artist");
            Console.WriteLine("10. Delete Album");
            Console.WriteLine("11. Delete Song");
            Console.WriteLine("12. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddArtist(); break;
                case "2": AddAlbum(); break;
                case "3": AddSong(); break;
                case "4": ViewArtists(); break;
                case "5": ViewAlbums(); break;
                case "6": ViewSongs(); break;
                case "7": ViewHistory(); break;
                case "8": ViewStatistics(); break;
                case "9": Delete.DeleteArtist(artists, histories); break;
                case "10": Delete.DeleteAlbum(albums, histories); break;
                case "11": Delete.DeleteSong(songs, histories); break;
                case "12": SaveAllData(); return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddArtist()
    {
        Console.Write("Enter artist name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid input. Name cannot be empty.");
            return;
        }
        var artist = new Artist { Name = name };
        artists.Add(artist);
        histories.Add(new History { Action = $"Artist added: {name}", Date = DateTime.Now });
        Console.WriteLine($"Artist {name} has been added.");
    }

    static void AddAlbum()
    {
        Console.Write("Enter album title: ");
        string? title = Console.ReadLine();
        Console.Write("Enter artist name: ");
        string? artistName = Console.ReadLine();

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(artistName))
        {
            Console.WriteLine("Invalid input. Title or artist name cannot be empty.");
            return;
        }

        var artist = artists.Find(a => a.Name == artistName);
        if (artist == null)
        {
            Console.WriteLine("Artist not found.");
            return;
        }

        var album = new Album { Title = title, Artist = artist };
        albums.Add(album);
        histories.Add(new History { Action = $"Album added: {title} by {artistName}", Date = DateTime.Now });
        Console.WriteLine($"Album {title} by {artistName} has been added.");
    }

    static void AddSong()
    {
        Console.Write("Enter song title: ");
        string? title = Console.ReadLine();
        Console.Write("Enter album title: ");
        string? albumTitle = Console.ReadLine();

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(albumTitle))
        {
            Console.WriteLine("Invalid input. Title or album name cannot be empty.");
            return;
        }

        var album = albums.Find(a => a.Title == albumTitle);
        if (album == null)
        {
            Console.WriteLine("Album not found.");
            return;
        }

        var song = new Song { Title = title, Album = album };
        songs.Add(song);
        histories.Add(new History { Action = $"Song added: {title} from album {albumTitle}", Date = DateTime.Now });
        Console.WriteLine($"Song {title} from album {albumTitle} has been added.");
    }

    static void ViewArtists()
    {
        foreach (var artist in artists)
        {
            Console.WriteLine($"Artist: {artist.Name}");
        }
        Console.ReadKey();
    }

    static void ViewAlbums()
    {
        foreach (var album in albums)
        {
            
            Console.WriteLine($"Album: {album.Title}, Artist: {album.Artist?.Name ?? "Unknown"}");
        }
        Console.ReadKey();
    }

    static void ViewSongs()
    {
        foreach (var song in songs)
        {
            
            Console.WriteLine($"Song: {song.Title}, Album: {song.Album?.Title ?? "Unknown"}");
        }
        Console.ReadKey();
    }

    static void ViewHistory()
    {
        foreach (var history in histories)
        {
            Console.WriteLine($"Action: {history.Action}, Date: {history.Date}");
        }
        Console.ReadKey();
    }

    static void ViewStatistics()
    {
        Console.WriteLine($"Total artists: {artists.Count}");
        Console.WriteLine($"Total albums: {albums.Count}");
        Console.WriteLine($"Total songs: {songs.Count}");
        Console.ReadKey();
    }

    static void SaveAllData()
    {
        DataManager.SaveData(artists, "artists.json");
        DataManager.SaveData(albums, "albums.json");
        DataManager.SaveData(songs, "songs.json");
        DataManager.SaveData(histories, "history.json");
        Console.WriteLine("All data has been saved.");
    }
}
