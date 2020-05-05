public class InvalidSongMinutesException : InvalidSongLengthException
{
    public const int MIN_MINUTES = 0;
    public const int MAX_MINUTES = 14;

    public override string Message => $"Song minutes should be between {MIN_MINUTES} and {MAX_MINUTES}.";
}
