using System.Runtime.Serialization;

namespace StringCalculator;

[Serializable]
internal class NegativeNumberFoundException : Exception
{
    public NegativeNumberFoundException()
    {
    }
}