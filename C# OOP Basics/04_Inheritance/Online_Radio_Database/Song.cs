public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < InvalidArtistNameException.MIN_ARTIST_NAME_LENGTH || value.Length > InvalidArtistNameException.MAX_ARTIST_NAME_LENGTH)
            {
                throw new InvalidArtistNameException();
            }
            artistName = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < InvalidSongNameException.MIN_SONG_NAME_LENGTH || value.Length > InvalidArtistNameException.MAX_ARTIST_NAME_LENGTH)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < InvalidSongMinutesException.MIN_MINUTES || value > InvalidSongMinutesException.MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < InvalidSongSecondsException.MIN_SECONDS || value > InvalidSongSecondsException.MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }
}
