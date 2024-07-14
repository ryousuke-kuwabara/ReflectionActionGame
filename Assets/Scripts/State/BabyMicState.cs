using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMicState : IState
{
    public BabyController baby { get; }

    public BabyMicState(BabyController baby)
    {
        this.baby = baby;
    } 

    public void Enter()
    {
        this.baby.Animator.StartMic();
        this.baby.Status.StopMove();

        SoundManager.Instance.PlayLoopSe(SeName.GetBabyMike);
    }

    public void Exit()
    {
        this.baby.Animator.StopMic();
        this.baby.Status.RestartMove();

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {
        
    }
}
