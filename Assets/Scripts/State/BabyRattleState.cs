using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRattleState : IState
{
    public BabyController baby { get; }

    public BabyRattleState(BabyController baby)
    {
        this.baby = baby;
    } 

    public void Enter()
    {
        this.baby.Animator.StartRattle();
        this.baby.Status.StopMove();

        SoundManager.Instance.PlayLoopSe(SeName.GetBabyRattle);
    }

    public void Exit()
    {
        this.baby.Animator.StopRattle();
        this.baby.Status.RestartMove();

        SoundManager.Instance.StopLoopSe();
    }

    public void Update()
    {
        
    }
}
