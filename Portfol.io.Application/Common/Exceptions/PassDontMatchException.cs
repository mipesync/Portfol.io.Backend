namespace Portfol.io.Application.Common.Exceptions
{
    public class PassDontMatchException : Exception
    {
        public PassDontMatchException() : base("Passwords don't match.") {}
    }
}
