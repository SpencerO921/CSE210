/// <summary>
/// Represents a fraction with a numerator and denominator.
/// This is more accurate than storing numbers in a double.
/// </summary>
public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int whole)
    {
        _numerator = whole;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    

    public string GetFractionString()
    {
        string representation = $"{_numerator} / {_denominator}";
        return representation;
    }

    public double GetDecimalValue()
    {
        // (double) makes it not integer division
        double value = (double)_numerator / (double)_denominator;
        return value;
    }
}