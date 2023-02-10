
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{
    private ILogger _logger;
    private IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
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
        try
        {
            _logger.Write(answer.ToString());
        } catch (LoggerException ex)
        {
            _webService.NotifyOfFailedLogging(ex.Message);
        }
        

        return answer;
    }
}

public interface ILogger
{
    void Write(string messsage);
}


public interface IWebService
{
    void NotifyOfFailedLogging(string message);
}

public class LoggerException : ApplicationException
{
    public string Message { get; private set; } = "";
    public LoggerException(string message)
    {
        Message = message;
    }
}
