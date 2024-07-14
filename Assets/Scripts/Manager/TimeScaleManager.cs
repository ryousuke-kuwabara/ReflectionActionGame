using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    [SerializeField] private BabyController _baby;
    [SerializeField] private float _speedScaleRatePerSecond;
    [SerializeField] private GameObject _option;

    private float _timer;

    private void Start()
    {
        _timer = 0f;
        SoundManager.Instance.PlayBgm(BgmName.Main);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1)
        {
            _baby.Status.ApplyDifficultySpeedMultiplier(_speedScaleRatePerSecond);
            _timer = 0f;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!(hasFocus))
        {
            _option.SetActive(true);
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            _option.SetActive(true);
        }
    }
}
