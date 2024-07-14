using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyStatus : MonoBehaviour
{
    const float SPEED_MIN = 1f;

    [SerializeField] private float _initialSpeed;
    [SerializeField] private float _initialAngle;

    [SerializeField] private float _currentSpeed; // Serializing for test.
    
    public float _difficultySpeedMultiplier;
    private float _itemSpeedMultiplier;

    private bool _isStop;

    private void Start()
    {
        _difficultySpeedMultiplier = 1.0f;
        _isStop = false;
    }

    public void ApplySpeedMultipiler(float multipiler)
    {
        _itemSpeedMultiplier += multipiler;
    }

    public float GetInitialAngle()
    {
        return this._initialAngle;
    }

    public float GetCurrentSpeed()
    {
        if (_isStop == true)
        {
            return 0f;
        }

        _currentSpeed = Mathf.Clamp(_initialSpeed * _difficultySpeedMultiplier * Mathf.Clamp(_itemSpeedMultiplier, SPEED_MIN, 9999f), SPEED_MIN, 9999f);
        return _currentSpeed;
    }

    public float GetInitialSpeed()
    {
        return _initialSpeed;
    }

    public void ApplyDifficultySpeedMultiplier(float multiplier)
    {
        _difficultySpeedMultiplier += multiplier;
    }

    public void StopMove()
    {
        _isStop = true;
    }

    public void RestartMove()
    {
        _isStop = false;
    }
}
