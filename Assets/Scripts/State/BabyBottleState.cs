using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBottleState : IState
{
    public BabyController baby { get; }

    public BabyBottleState(BabyController baby)
    {
        this.baby = baby;
    } 

    public void Enter()
    {
        this.baby.Animator.StartBottle();
        this.baby.Status.StopMove();

        SoundManager.Instance.PlayLoopSe(SeName.GetBabyBottle);
    }

    public void Exit()
    {
        this.baby.Animator.StopBottle();
        this.baby.Status.RestartMove();

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {
        
    }
}
