using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCarState : IState
{
    public BabyController baby { get; }
    private float _moveSpeed;

    public BabyCarState(BabyController baby)
    {
        this.baby = baby;
    }

    public void Enter()
    {
        this.baby.Animator.StartCar();
        this.baby.Status.ApplySpeedMultipiler(2.0f);

        SoundManager.Instance.PlayLoopSe(SeName.GetBabyCar);
    }

    public void Exit()
    {
        this.baby.Animator.StopCar();
        this.baby.Status.ApplySpeedMultipiler(-2.0f);

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {

    }
}
