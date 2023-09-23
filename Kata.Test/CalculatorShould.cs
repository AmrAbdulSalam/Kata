using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Kata.Test;

public class CalculatorShould
{
    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2", 3)]
    [InlineData("1", 1)]
    [InlineData("", 0)]
    public void Add_More_Than_One_Value(string numbers, int output)
    {
        var calcualtor = new Calculator();

        var total = calcualtor.Add(numbers);

        Assert.Equal(total, output);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9,10,11,12,13",91)]
    public void Add_Unkown_Amount_Of_Numbers(string numbers, int output)
    {
        var calcualtor = new Calculator();

        var total = calcualtor.Add(numbers);

        Assert.Equal(total, output);
    }

    [Theory]
    [InlineData("1\n2,3" , 6)]
    public void Handle_New_Lines_Between_Numbers(string numbers, int output)
    {
        var calcualtor = new Calculator();

        var total = calcualtor.Add(numbers);

        Assert.Equal(total, output);
    }


    [Theory]
    [InlineData("//;\n1;1,1", 3)]
    [InlineData("//i\n1i1i1", 3)]
    [InlineData("//~\n1~2~5~9", 17)]
    public void Support_Different_Delimiters(string numbers, int output)
    {
        var calcualtor = new Calculator();

        var total = calcualtor.Add(numbers);

        Assert.Equal(total, output);
    }

    [Theory]
    [InlineData("1,4,-1")]
    [InlineData("-1")]
    public void Thrown_Exception_When_Negative_Value_Passed(string numbers)
    {
        var calcualtor = new Calculator();

        Action total = () => calcualtor.Add(numbers);

        Assert.Throws<NegativeValuesException>(total);
    }
}