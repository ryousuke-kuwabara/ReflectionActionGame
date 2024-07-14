using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCrawlState : IState
{
    public BabyController baby { get; }

    public BabyCrawlState(BabyController baby)
    {
        this.baby = baby;
    }

    public void Enter()
    {
        this.baby.Animator.StartCrawl();

        SoundManager.Instance.PlayLoopSe(SeName.BabyCrawl);
    }

    public void Exit()
    {
        this.baby.Animator.StopCrawl();

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {
        // float moveSpeed = this.baby.Status.GetSpeed();
        // this.baby.Mover.GoForward(moveSpeed);
    }
}
