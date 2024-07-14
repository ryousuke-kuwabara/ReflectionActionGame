using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWalkerState : IState
{
    public BabyController baby { get; }
    private float moveSpeed;

    public BabyWalkerState(BabyController baby)
    {
        this.baby = baby;
    }

    public void Enter()
    {
        this.baby.Animator.StartWalker();
        this.baby.Status.ApplySpeedMultipiler(1.3f);
    }

    public void Exit()
    {
        this.baby.Animator.StopWalker();
        this.baby.Status.ApplySpeedMultipiler(-1.3f);
    }

    public void Update()
    {

    }
}
