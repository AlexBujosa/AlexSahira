// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
public class Range
{
    public enum OpenSymbols
    { 
        OpenSquareBraket = 0,
        OpenParenthesis = 1,
        None = 2
    }
    public enum CloseSymbols
    {
        CloseSquareBraket = 0,
        CloseParenthesis = 1,
        None = 2
    }

    public string newRange;
    public string saveRange;
    public int[] newRangeNumber = new int[2];
    public OpenSymbols open;
    public CloseSymbols close;
    public Range(string oldRange)
    {
        newRange = Regex.Replace(oldRange, " ", "");
        saveRange = newRange;
        CheckSymbolOpCL(newRange);
        open = OpenSymbolsAssign(newRange);
        close = CloseSymbolsAssign(newRange);
        newRange = newRange.Substring(1,newRange.Length - 2);
        string[] strings = newRange.Split(',');
        invalidRange(strings);
        newRangeNumber = TryParsingStringArray(strings);
        isMinorOrEqualThan(newRangeNumber);
    }
    public void invalidRange(string[] strings)
    {
        if (strings.Length != 2)
            throw new Exception("Su rango es invalido!!!");
    }
    public void isMinorOrEqualThan(int[] range)
    {
        if (range[0] > range[1])
            throw new Exception("El primer numero debe ser menor o igual al segundo!!!");
    }
    public void CheckSymbolOpCL(string strings)
    {
        if (strings[0] != '[' && strings[0] != '(')
            throw new Exception("No contiene los simbolos de entrada correctos");
        if (strings[strings.Length - 1] != ']' && strings[strings.Length - 1] != ')')
            throw new Exception("No Contiene los simbolos de cerrada correctos");
    }
    public OpenSymbols OpenSymbolsAssign(string strings)
    {
        OpenSymbols OpenSymbols = OpenSymbols.None;
        if (strings[0] == '[')
        {
            OpenSymbols = OpenSymbols.OpenSquareBraket;
        }
        else if (strings[0] == '(')
        {
            OpenSymbols = OpenSymbols.OpenParenthesis;
        }
        return OpenSymbols;
    }
    public CloseSymbols CloseSymbolsAssign(string strings)
    {
        CloseSymbols cl = CloseSymbols.None;
        if (strings[strings.Length - 1] == ']')
        {
            cl = CloseSymbols.CloseSquareBraket;
        }
        else if (strings[strings.Length - 1] == ')')
        {
            cl = CloseSymbols.CloseParenthesis;
        }
        return cl;
    }
    public int[] TryParsingStringArray(string[] strings)
    {
        int[] creatingRange = new int[2];
        bool valido;
        //int result;
        for (int i = 0; i < strings.Length; i++)
        {
            valido = Int32.TryParse(strings[i], out int result);
            if (valido)
                creatingRange[i] = result;
            else
                throw new Exception("Su rango es invalido!!!, contiene valores tipo carácter");

        }
        return creatingRange;
    }
    public string NumberContaining(List<int> numberContaining)
    {
        string valueString = "{";
        for (int i = 0; i < numberContaining.Count - 1; i++)
        {
            valueString += numberContaining[i] + ",";
        }
        valueString += numberContaining[numberContaining.Count - 1] + "}";
        return valueString;

    }
    public List<int> ContainedNumbers(int[] range, OpenSymbols op, CloseSymbols cl)
    {
        List<int> newRange = new List<int>();
        (int firstDigit, int secondDigit) = ReturnFirstSecondDigit(range, op, cl);

        for (int i = firstDigit; i < secondDigit; i++)
            newRange.Add(i);

        return newRange;
    }
    public (int, int) ReturnFirstSecondDigit(int[] range, OpenSymbols op, CloseSymbols cl)
    {
        int firstDigit = range[0];
        int secondDigit = range[1];

        if (OpenSymbols.OpenParenthesis == op)
            firstDigit += 1;
        if (CloseSymbols.CloseParenthesis == cl)
            secondDigit -= 1;

        return (firstDigit, secondDigit);
    }
    public string GetAllPoints()
    {
        (int firstDigit, int secondDigit) = ReturnFirstSecondDigit(newRangeNumber, open, close);
        string allpoint = "{";
        for (int i = firstDigit; i < secondDigit; i++)
        {
            allpoint += i + ",";
        }
        allpoint += (secondDigit).ToString() + "}";
        return $"{saveRange} allPoints = {allpoint}";
    }
    public string IntegerRangeContain(List<int> values)
    {
        if (values.Count == 0)
            throw new Exception("Error: No ingreso elementos, conjunto vacio!!!");

        List<int>  range = ContainedNumbers(newRangeNumber, open, close);
        for (int i = 0; i < values.Count; i++)
        {
            bool valid = range.Contains(values[i]);
            if (!valid)
            {
                return $"{saveRange} doesn't contain ";
            }
        }
        return $"{saveRange} contains ";
    }
    public string AtLeastOneCollisionNeed(List<int> values)
    {

        if (values.Count == 0)
            throw new Exception("Error: No ingreso elementos, conjunto vacio!!!");

        List<int> range = ContainedNumbers(newRangeNumber, open, close);
        for (int i = 0; i < values.Count; i++)
        {
            bool valid = range.Contains(values[i]);
            if (valid)
            {
                return $"{saveRange} overlaps with ";
            }
        }
        return $"{saveRange} doesn'+t overlap with ";
    }
    public string endPoints()
    {
        int fValue = newRangeNumber[0];
        int sValue = newRangeNumber[1];
        string OpenSymbol = "[";
        string CloseSymbol = "]";
        string OpenBraket = "{";
        string CloseBraket = "}";
        if (OpenSymbols.OpenParenthesis == open)
        {
            fValue += 1;
            OpenSymbol = "(";
        }

        if (CloseSymbols.CloseParenthesis == close)
        {
            sValue -= 1;
            CloseSymbol = ")";
        }
        return $"{OpenSymbol}{newRangeNumber[0]},{newRangeNumber[1]}{CloseSymbol} endPoints = {OpenBraket}{fValue},{sValue}{CloseBraket}";


    }
    public string ContainRange(string strings)
    {
        string secondNewRange = Regex.Replace(strings, " ", "");
        CheckSymbolOpCL(strings);
        OpenSymbols openSymbols = OpenSymbolsAssign(secondNewRange);
        CloseSymbols closeSymbols = CloseSymbolsAssign(secondNewRange);
        var secondRange = secondNewRange.Substring(1, secondNewRange.Length - 2);
        string[] splitStr = secondRange.Split(',');
        invalidRange(splitStr);
        var newSecondNumberRange = TryParsingStringArray(splitStr);
        isMinorOrEqualThan(newSecondNumberRange);
        List<int> ints = ContainedNumbers(newSecondNumberRange, openSymbols, closeSymbols);
        string rangeContain = IntegerRangeContain(ints);

        return rangeContain + secondNewRange;
    }
    public string OverlapRange(string strings)
    {
        string secondNewRange = Regex.Replace(strings, " ", "");
        CheckSymbolOpCL(strings);
        OpenSymbols openSymbols = OpenSymbolsAssign(secondNewRange);
        CloseSymbols closeSymbols = CloseSymbolsAssign(secondNewRange);
        var secondRange = secondNewRange.Substring(1, secondNewRange.Length - 2);
        string[] splitStr = secondRange.Split(',');
        invalidRange(splitStr);
        var newSecondNumberRange = TryParsingStringArray(splitStr);
        isMinorOrEqualThan(newSecondNumberRange);
        List<int> ints = ContainedNumbers(newSecondNumberRange, openSymbols, closeSymbols);
        string overlaps = AtLeastOneCollisionNeed(ints);
        return overlaps + secondNewRange;
    }
    public string Equals(string otherStr)
    {
        string newStr;
        if (otherStr == saveRange)
        {
            newStr = saveRange + " equals " + otherStr;
        }else
        {
            newStr = saveRange + " neq " + otherStr;
        }
        return newStr;
    }
}
