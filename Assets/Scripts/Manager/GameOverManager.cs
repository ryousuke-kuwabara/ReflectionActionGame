using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Stage _gameOverHandler;
    [SerializeField] private GameObject _gameOverImageObject;
    [SerializeField] private GameObject _gameOverBackGround;

    [SerializeField] private int finalPositionY;
    [SerializeField] private int dropDuration;

    [SerializeField] private int bounceHeight;
    [SerializeField] private int bounceDuration;

    private Image _gameOverImage;

    private void Start()
    {
        if (_gameOverImageObject.activeSelf == true)
        {
            _gameOverImageObject.SetActive(false);
        }

        if (_gameOverBackGround.activeSelf == true)
        {
            _gameOverBackGround.SetActive(false);
        }

        _gameOverHandler._onGameOver += ShowGameOverImage;
    }

    private void ShowGameOverImage()
    {
        _gameOverImageObject.SetActive(true);
        _gameOverBackGround.SetActive(true);
        SoundManager.Instance.PlaySe(SeName.GameOver);
    }

    /*
    private void ShowGameOverAnim()
    {
        _gameOverImageObject.SetActive(true);

        _gameOverImage.DOAnchorPosY(finalPositionY, dropDuration).SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                // バウンドアニメーション
                gameOverImage.DOAnchorPosY(finalPositionY + bounceHeight, bounceDuration).SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        gameOverImage.DOAnchorPosY(finalPositionY, bounceDuration / 2).SetEase(Ease.InQuad);
                    });
            });
    }
    */
}
