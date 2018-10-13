using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteGenre = Console.ReadLine();
            string favouriteDuration = Console.ReadLine();
            string movieInfo = Console.ReadLine();

            var movies = new Dictionary<string, TimeSpan>();
            TimeSpan totalPlaylistDuration = TimeSpan.Zero;

            while (movieInfo != "POPCORN!")
            {
                string[] movieArgs = movieInfo.Split('|');
                string movieName = movieArgs[0];
                string genre = movieArgs[1];
                TimeSpan duration = TimeSpan.Parse(movieArgs[2]);

                if (genre == favouriteGenre)
                {
                    movies.Add(movieName, duration);
                }

                totalPlaylistDuration = totalPlaylistDuration.Add(duration);
                movieInfo = Console.ReadLine();
            }

            string wifeAnswer;

            if (favouriteDuration == "Short")
            {
                foreach (var movie in movies.OrderBy(x => x.Value))
                {
                    wifeAnswer = Console.ReadLine();
                    if (wifeAnswer != "Yes")
                    {
                        Console.WriteLine(movie.Key);
                    }
                    else
                    {
                        Console.WriteLine(movie.Key);
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        break;
                    }
                }
            }
            else if (favouriteDuration == "Long")
            {
                foreach (var movie in movies.OrderByDescending(x => x.Value))
                {
                    wifeAnswer = Console.ReadLine();
                    if (wifeAnswer != "Yes")
                    {
                        Console.WriteLine(movie.Key);
                    }
                    else
                    {
                        Console.WriteLine(movie.Key);
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        break;
                    }
                }
            }

            Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
        }
    }
}
