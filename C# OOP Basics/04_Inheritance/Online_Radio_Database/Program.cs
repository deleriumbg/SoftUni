using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfSongs = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            string[] songInput = Console.ReadLine().Split(';');
            string artistName = songInput[0];
            string songName = songInput[1];
            string[] time = songInput[2].Split(':');
            try
            {
                bool validMinutes = int.TryParse(time[0], out int minutes);
                bool validSeconds = int.TryParse(time[1], out int seconds);
                if (validMinutes == false || validSeconds == false)
                {
                    throw new InvalidSongLengthException();
                }
                Song song = new Song(artistName, songName, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongLengthException invalidLenghtEx)
            {
                Console.WriteLine(invalidLenghtEx.Message);
            }
            catch (Exception invalidSongEx)
            {
                Console.WriteLine(invalidSongEx.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");
        int totalSongSeconds = songs.Sum(x => x.Seconds + x.Minutes * 60);
        TimeSpan totalTime = TimeSpan.FromSeconds(totalSongSeconds);
        string result = string.Format($"{totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
        Console.WriteLine($"Playlist length: {result}");
    }
}
