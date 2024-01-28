namespace Utilities.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Message { get; }
        public BadRequestException(string message)
        {
            Message = message;
        }
    }
}
