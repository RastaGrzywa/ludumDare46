using UnityEngine;

public class HugeNumber
{
    private float value = 0.0f;
    private HugeNumberIndexEnum index = HugeNumberIndexEnum.A;

    public HugeNumber(float value, HugeNumberIndexEnum index)
    {
        this.value = value;
        this.index = index;
    }

    public string GetNumberString()
    {
        //HugeNumber hn = ToHighestPossible();

        ////int i = (int) index;
        ////while (value > 10000)
        ////{
        ////    i++;
        ////    value /= 1000;
        ////}
        ///
        float formattedNumber = Mathf.Round(value * 1000) / 1000;
        string formattedText = "";

        if (formattedNumber < 10)
        {
            formattedText = formattedNumber.ToString("F2");
        } 
        else if (formattedNumber < 100)
        {
            formattedText = formattedNumber.ToString("F1");
        } 
        else
        {
            formattedText = Mathf.Round(formattedNumber).ToString();
        }

        return formattedText + " " + index;
    }

    private HugeNumber ToHighestPossible()
    {
        float v = value;
        HugeNumberIndexEnum hni = index;

        while (v > 10000)
        {
            v /= 1000;
            hni++;
        }
        while (v < 0.0001)
        {
            v *= 1000;
            hni--;
        }

        return new HugeNumber(v, hni);
    }

    public void Add(HugeNumber hugeNumber)
    {
        if (hugeNumber.index == index)
            value += hugeNumber.value;
    }
    public void Subtract(HugeNumber hugeNumber)
    {

        value -= hugeNumber.value;
    }

    public float GetValue()
    {
        return value;
    }
    public HugeNumberIndexEnum GetIndex()
    {
        return index;
    }


    public HugeNumber ConvertToCurrentFormat(HugeNumber hugeNumber)
    {
        return Convert(hugeNumber.value, hugeNumber.index);

    }
    private HugeNumber Convert(float number, HugeNumberIndexEnum indexEnum)
    {
        if (indexEnum > index)
        {
            indexEnum--;
            number *= 1000;
            Convert(number, indexEnum);
        }
        else if (indexEnum < index)
        {
            indexEnum++;
            number /= 1000;
            Convert(number, indexEnum);
        }
        return new HugeNumber(number, indexEnum);
    }

    // display 1A; 10A; 100A; 1 000A; 1,00B; 10,0B; 100B; 1 000B; 
    // max: 999
    // min: 1,00
}