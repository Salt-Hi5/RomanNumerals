namespace RomanNumerals;

public class RomanConverter
{
    public string ConvertToRoman(int number)
    {
        if (number < 1) throw new ArgumentException("The number cannot be lower than 1");
        if (number > 4999) throw new ArgumentException("The number cannot be higher than 4999");

        var reversedDigitArray = number.ToString().Select(x => int.Parse(x.ToString())).Reverse().ToArray();
        var romanNumeralArray = reversedDigitArray.Select((digit, powerOfTen) => GetRomanNumeral(reversedDigitArray[powerOfTen], powerOfTen)).Reverse();

        return String.Join("", romanNumeralArray);
    }

    private string GetRomanNumeral(int digit, int powerOfTen)
    {
        var conversions = new Dictionary<int, string>()
        {
            {1,"I"},{2,"II"},{3,"III"},{4,"IV"},{5,"V"},{6,"VI"},{7,"VII"},{8,"VIII"},{9,"IX"},{0,string.Empty}
        };

        var returnString = conversions[digit];

        switch (powerOfTen)
        {
            case 1: return returnString.Replace("X", "C").Replace("V", "L").Replace("I", "X");
            case 2: return returnString.Replace("X", "M").Replace("V", "D").Replace("I", "C");
            case 3: return String.Join("", Enumerable.Repeat("M", digit));
            default: return returnString;
        }
    }






    // The first solution I came up with for the helper method
    private string OLD_GetRomanNumeral(int digit, int powerOfTen)
    {
        var numerals = new Dictionary<int, string>();

        switch (powerOfTen)
        {
            case 0: numerals.Add(1, "I"); numerals.Add(5, "V"); numerals.Add(10, "X"); break;
            case 1: numerals.Add(1, "X"); numerals.Add(5, "L"); numerals.Add(10, "C"); break;
            case 2: numerals.Add(1, "C"); numerals.Add(5, "D"); numerals.Add(10, "M"); break;
            case 3: return String.Join("", Enumerable.Repeat("M", digit));
        }

        switch (digit)
        {
            case 1: return numerals[1]!;
            case 2: return numerals[1]! + numerals[1]!;
            case 3: return numerals[1]! + numerals[1]! + numerals[1]!;
            case 4: return numerals[1]! + numerals[5]!;
            case 5: return numerals[5]!;
            case 6: return numerals[5]! + numerals[1]!;
            case 7: return numerals[5]! + numerals[1]! + numerals[1]!;
            case 8: return numerals[5]! + numerals[1]! + numerals[1]! + numerals[1]!;
            case 9: return numerals[1]! + numerals[10]!;
            default: return string.Empty;
        }
    }
}