
using UnityEngine;

public class HugeNumberUtils
{
    public static HugeNumber AddTwoNumbers(HugeNumber first, HugeNumber second)
    {
        HugeNumber number1 = ConvertToLargestIndexPossible(new HugeNumber(first.GetValue(), first.GetIndex()));
        HugeNumber number2 = ConvertToLargestIndexPossible(new HugeNumber(second.GetValue(), second.GetIndex()));

        if (number1.GetIndex() == number2.GetIndex())
        {
            return ConvertToLargestIndexPossible(new HugeNumber(number1.GetValue() + number2.GetValue(), number1.GetIndex()));
        }

        float difference = Mathf.Abs(number1.GetIndex() - number2.GetIndex());


        if (number1.GetIndex() > number2.GetIndex())
        {
            return AddNumbersByDifference(number1, number2, difference);
        }

        if (number1.GetIndex() < number2.GetIndex())
        {
            return AddNumbersByDifference(number2, number1, difference);
        }


        return null;
    }

    private static HugeNumber AddNumbersByDifference(HugeNumber first, HugeNumber second, float difference)
    {
        if (difference > 2)
        {
            return first;
        }

        if (difference == 1)
        {
            return ConvertToLargestIndexPossible(new HugeNumber(first.GetValue() + (second.GetValue() / 1000), first.GetIndex()));
        }

        if (difference == 2)
        {
            return ConvertToLargestIndexPossible(new HugeNumber(first.GetValue() + (second.GetValue() / 1000000), first.GetIndex()));
        }
        return null;
    }

    public static HugeNumber ConvertToLargestIndexPossible(HugeNumber number)
    {
        float v = number.GetValue();
        HugeNumberIndexEnum hni = number.GetIndex();
        while (v >= 1000)
        {
            v /= 1000;
            hni++;
        }
        while (v < 0)
        {
            v *= 1000;
            hni--;
        }
        return new HugeNumber(v, hni);
    }


    // first greater than second
    public static HugeNumber SubtractTwoNumbers(HugeNumber first, HugeNumber second)
    {

        HugeNumber number1 = ConvertToLargestIndexPossible(new HugeNumber(first.GetValue(), first.GetIndex()));
        HugeNumber number2 = ConvertToLargestIndexPossible(new HugeNumber(second.GetValue(), second.GetIndex()));

        if (number1.GetIndex() == number2.GetIndex())
        {
            return ConvertToLargestIndexPossible(new HugeNumber(number1.GetValue() - number2.GetValue(), number1.GetIndex()));
        }

        float difference = Mathf.Abs(number1.GetIndex() - number2.GetIndex());

        if (difference > 2)
        {
            return number1;
        }

        if (difference == 1)
        {
            return ConvertToLargestIndexPossible(new HugeNumber(number1.GetValue() - (number2.GetValue() / 1000), number1.GetIndex()));
        }

        if (difference == 2)
        {
            return ConvertToLargestIndexPossible(new HugeNumber(number1.GetValue() - (number2.GetValue() / 1000000), number1.GetIndex()));
        }

        return null;
    }
}
