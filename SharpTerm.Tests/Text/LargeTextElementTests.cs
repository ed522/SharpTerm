using SharpTerm.Text;
using NUnit.Framework;

namespace SharpTerm.Tests.Text;

[TestFixture]
public class LargeTextElementTests
{
    [Test]
    public void LargeTextElement_WrapsText()
    {
        var testString = "This is a test string that should be wrapped-across multiple lines:when rendered in a LargeTextElement.";
        var expectedLines = new[]
        {
            "This is a test string ",
            "that should be wrapped-", 
            "across multiple lines:",
            "when rendered in a ",
            "LargeTextElement."
        };
        var realLines = LargeTextElement.WrapText(testString, 25);
        Assert.Equals(expectedLines, realLines);
    }
}