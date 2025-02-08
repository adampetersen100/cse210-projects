using System;
using System.Diagnostics;
using System.Xml.Schema;
public class Fraction
{
    private int _top;
    private int _bottom;


    public Fraction()
    {
        _top = 1;
        _bottom = 1;
        return;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
        return ;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string fraction = ($"{_top}/{_bottom}");
        return fraction;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}