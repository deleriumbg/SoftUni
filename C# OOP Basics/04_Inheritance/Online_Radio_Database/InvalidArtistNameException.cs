public class InvalidArtistNameException : InvalidSongException
{
    public const int MIN_ARTIST_NAME_LENGTH = 3;
    public const int MAX_ARTIST_NAME_LENGTH = 20;

    public override string Message => $"Artist name should be between {MIN_ARTIST_NAME_LENGTH} and {MAX_ARTIST_NAME_LENGTH} symbols.";
}
