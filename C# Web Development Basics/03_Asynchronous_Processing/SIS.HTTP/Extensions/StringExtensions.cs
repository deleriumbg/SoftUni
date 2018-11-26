namespace SIS.HTTP.Extensions
{
    public class StringExtensions
    {
        public static string Capitalize(string message)
        {
            return $"{char.ToUpper(message[0])}{message.Substring(1).ToLower()}";
        }
    }
}
