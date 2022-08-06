namespace Portfol.io.Application.Common.Exceptions
{
    public class DoesNotMatchException : Exception
    {
        public DoesNotMatchException(string inputName, string patternName) : base($"The input \"{inputName}\" doesn't match the pattern \"{patternName}\".") {}
    }
}
