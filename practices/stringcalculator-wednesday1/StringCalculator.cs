
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{
    private ILogger _logger;

    public StringCalculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(string numbers)
    {
        int answer = 0;
        if (numbers.Equals(""))
        {
            answer = 0;
        }
        else
        {
            var nums = Regex.Split(numbers, @"[^\d-]+")
                .Where(s => Double.TryParse(s, out _))
                .Select(int.Parse);

            if (nums.Any(n => n < 0))
            {
                throw new NegativeNumberFoundException();
            }

            answer = nums.Sum();
        }

        _logger.Write(answer.ToString());
        _logger.Write(answer.ToString());
        _logger.Write(answer.ToString());

        return answer;
    }
}

public interface ILogger
{
    void Write(string messsage);
}
