using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lastRunScoreText;
    [SerializeField] private TextMeshProUGUI[] _topScoreTexts;

    [SerializeField] private GameObject _highScoreImage;

    private int _lastRunScore;
    private int[] _topScores = new int[3];

    private void Start()
    {
        _lastRunScore = PlayerPrefs.GetInt("currentRunScore", 0);
        LoadScores();

        AddScore(_lastRunScore);
        SaveScores();

        DisplayLastRunScore(_lastRunScore);
        DisplayTopScores(_topScores);
    }

    void LoadScores()
    {
        _topScores[0] = PlayerPrefs.GetInt("firstPlaceScore", 0);
        _topScores[1] = PlayerPrefs.GetInt("secondPlaceScore", 0);
        _topScores[2] = PlayerPrefs.GetInt("thirdPlaceScore", 0);
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt("firstPlaceScore", _topScores[0]);
        PlayerPrefs.SetInt("secondPlaceScore", _topScores[1]);
        PlayerPrefs.SetInt("thirdPlaceScore", _topScores[2]);
    }

    void AddScore(int score)
    {
        bool isScoreUpdated = false;

        if (score > _topScores[0])
        {
            _topScores[2] = _topScores[1];
            _topScores[1] = _topScores[0];
            _topScores[0] = score;

            isScoreUpdated = true;
        }
        else if (score > _topScores[1])
        {
            _topScores[2] = _topScores[1];
            _topScores[1] = score;

            isScoreUpdated = true;
        }
        else if (score > _topScores[2])
        {
            _topScores[2] = score;

            isScoreUpdated = true;
        }

        // スコアランキングの更新があった場合
        if (isScoreUpdated == true)
        {
            DisplayHighScoreImage();
            SoundManager.Instance.PlaySe(SeName.BestScoreUpdatedResult);
        } else
        {
            SoundManager.Instance.PlaySe(SeName.NormalResult);
        }
    }

    void DisplayLastRunScore(int score)
    {
        _lastRunScoreText.text = score.ToString();
    }

    void DisplayTopScores(int[] topScores)
    {
        _topScoreTexts[0].text = topScores[0].ToString();
        _topScoreTexts[1].text = topScores[1].ToString();
        _topScoreTexts[2].text = topScores[2].ToString();
    }

    void DisplayHighScoreImage()
    {
        _highScoreImage.SetActive(true);
    }
}
