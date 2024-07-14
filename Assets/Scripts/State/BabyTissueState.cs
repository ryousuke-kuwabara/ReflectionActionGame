using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTissueState : IState
{
    public BabyController baby { get; }

    public BabyTissueState(BabyController baby)
    {
        this.baby = baby;
    } 

    public void Enter()
    {
        this.baby.Animator.StartTissue();
        this.baby.Status.StopMove();

        SoundManager.Instance.PlayLoopSe(SeName.GetBabyTissue);
    }

    public void Exit()
    {
        this.baby.Animator.StopTissue();
        this.baby.Status.RestartMove();

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {
        
    }
}
