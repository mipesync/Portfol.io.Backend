namespace Portfol.io.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string name, object key) : base($"A {name} with this parameter \"{key}\" already exists.") { }
    }
}
