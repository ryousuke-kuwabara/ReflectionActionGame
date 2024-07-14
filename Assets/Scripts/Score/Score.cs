using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private readonly int _value;

    public Score(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _value = value;
    }

    public Score Add(int value)
    {
        return new Score(_value + value);
    }

    public int Value()
    {
        return _value;
    }
}
