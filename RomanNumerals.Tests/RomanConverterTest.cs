namespace RomanNumerals.Tests;
using FluentAssertions;
using Xunit;

public class RomanConverterTest
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    [InlineData(1743, "MDCCXLIII")]
    [InlineData(1400, "MCD")]
    [InlineData(3888, "MMMDCCCLXXXVIII")]
    [InlineData(3999, "MMMCMXCIX")]
    [InlineData(4999, "MMMMCMXCIX")]
    [InlineData(1444, "MCDXLIV")]
    [InlineData(1999, "MCMXCIX")]
    public void Test1(int input, string output)
    {
        // arrange 
        var romanConverter = new RomanConverter();

        // act
        var romanNumeral = romanConverter.ConvertToRoman(input);

        // assert
        romanNumeral.Should().Be(output);
    }
}