namespace System.Runtime.InteropServices {
    public class ExternalException :
#if CORECLR
        Exception
#else
        SystemException
#endif
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