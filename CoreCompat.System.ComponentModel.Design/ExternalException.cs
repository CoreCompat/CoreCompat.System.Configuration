namespace System.Runtime.InteropServices {
    public class ExternalException : SystemException
    {
        public ExternalException ()
        {
        }

        public ExternalException (string message)
            : base(message)
        {
        }

        public ExternalException (string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}