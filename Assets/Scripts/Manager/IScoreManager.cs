using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager
{
    public void AddScore(int value);
    public void SetScoreText(Score score);
}
