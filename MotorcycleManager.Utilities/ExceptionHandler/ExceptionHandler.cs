namespace MotorcycleManager.Utilities.ExceptionHandler
{
    public class ExceptionHandler : Exception
    {
        public ExceptionHandler() { }

        public ExceptionHandler(string message) : base(message) { }

        public ExceptionHandler(string message, Exception innerException) : base(message, innerException) { }
    }
}
