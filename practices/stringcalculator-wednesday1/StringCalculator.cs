
using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        return numbers
            .Equals("") ? 0 : 
            Regex.Split(numbers, @"[^\d]")
            .Where(s => Double.TryParse(s, out _))
            .Select(x => int.Parse(x))
            .Sum();
    }
}
