using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private int _baseScorePerSecond;

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Transform _canvas;
    [SerializeField] private Transform displayAddedScoreTextPosition;

    private Score _score;
    private BabyController _baby;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _score = new Score(0);
        this.SetScoreText(_score);
    }

    private void Start()
    {
        _baby = ItemTargetManager.Instance.Baby;
        InvokeRepeating("AddEverySecondScore", 1, 1);
    }

    private void AddEverySecondScore()
    {
        float currentSpeedBonus = _baby.Status.GetInitialSpeed() + (_baby.Status.GetCurrentSpeed() - _baby.Status.GetInitialSpeed());
        float everySecondScore = Mathf.Clamp((int)(_baseScorePerSecond * currentSpeedBonus), _baseScorePerSecond, 999999f);

        AddScore((int)everySecondScore);
    }

    public void SetScoreText(Score score)
    {
        int scoreValue = score.Value();
        _scoreText.SetText($"Score:{scoreValue}");

        PlayerPrefs.SetInt("currentRunScore", scoreValue);
    }

    public void AddScore(int value)
    {
        _score = _score.Add(value);

        this.SetScoreText(_score);
        this.DisplayAddScoreEffect(value);
    }

    public void AddItemScore(int value)
    {
        _score = _score.Add(value);

        this.SetScoreText(_score);
        this.DisplayItemAddScoreEffect(value);
    }

    public void DisplayItemAddScoreEffect(int value)
    {
        TextMeshProUGUI newAddedScoreText =
            Instantiate(_scoreText, new Vector2(_baby.transform.position.x, _baby.transform.position.y + 0.85f), Quaternion.identity, _canvas);

        newAddedScoreText.text = value.ToString();
        newAddedScoreText.AddComponent<AddedScoreText>();
    }

    public void DisplayAddScoreEffect(int value)
    {
        TextMeshProUGUI newAddedScoreText =
            Instantiate(_scoreText, displayAddedScoreTextPosition.position, Quaternion.identity, _canvas);

        newAddedScoreText.text = value.ToString();
        newAddedScoreText.AddComponent<AddedScoreText>();
    }
}
