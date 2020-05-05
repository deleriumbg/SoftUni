public class InvalidSongSecondsException : InvalidSongLengthException
{
    public const int MIN_SECONDS = 0;
    public const int MAX_SECONDS = 59;

    public override string Message => $"Song seconds should be between {MIN_SECONDS} and {MAX_SECONDS}.";
}
