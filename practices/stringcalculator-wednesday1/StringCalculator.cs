
using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers.Equals(""))
        {
            return 0;
        }
        var nums = Regex.Split(numbers, @"[^\d-]+")
        .Where(s => Double.TryParse(s, out _))
        .Select(x => int.Parse(x)).ToList<int>();

        if (nums.Any(n => n < 0))
        {
            throw new NegativeNumberFoundException();
        }
        return nums.Sum();
    }
}
