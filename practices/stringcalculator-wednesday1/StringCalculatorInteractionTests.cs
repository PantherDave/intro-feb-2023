using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2", "3")]
    public void AnswersAreLoggedToLogger(string numbers, string expected)
    {

        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object);

        calculator.Add(numbers);

        mockedLogger.Verify(logger => logger.Write(expected), Times.Once);
    }
}
