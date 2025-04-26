using System;
using System.Collections.Generic;
using MusicCollection;  

public static class Delete
{
    public static void DeleteArtist(List<Artist> artists, List<History> histories)
    {
        Console.WriteLine("Select an artist to delete:");
        for (int i = 0; i < artists.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {artists[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int artistIndex) && artistIndex >= 1 && artistIndex <= artists.Count)
        {
            var artist = artists[artistIndex - 1];
            artists.RemoveAt(artistIndex - 1);
            histories.Add(new History { Action = $"Artist deleted: {artist.Name}" });
            Console.WriteLine($"Artist {artist.Name} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public static void DeleteAlbum(List<Album> albums, List<History> histories)
    {
        Console.WriteLine("Select an album to delete:");
        for (int i = 0; i < albums.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {albums[i].Title} - {albums[i].Artist.Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int albumIndex) && albumIndex >= 1 && albumIndex <= albums.Count)
        {
            var album = albums[albumIndex - 1];
            albums.RemoveAt(albumIndex - 1);
            histories.Add(new History { Action = $"Album deleted: {album.Title} by {album.Artist.Name}" });
            Console.WriteLine($"Album {album.Title} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public static void DeleteSong(List<Song> songs, List<History> histories)
    {
        Console.WriteLine("Select a song to delete:");
        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {songs[i].Title} - {songs[i].Album.Title}");
        }

        if (int.TryParse(Console.ReadLine(), out int songIndex) && songIndex >= 1 && songIndex <= songs.Count)
        {
            var song = songs[songIndex - 1];
            songs.RemoveAt(songIndex - 1);
            histories.Add(new History { Action = $"Song deleted: {song.Title} from {song.Album.Title}" });
            Console.WriteLine($"Song {song.Title} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
