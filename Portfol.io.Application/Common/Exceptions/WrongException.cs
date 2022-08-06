namespace Portfol.io.Application.Common.Exceptions
{
    public class WrongException : Exception
    {
        public WrongException(string name) : base($"The property \"{name}\" is wrong.") { }
    }
}
