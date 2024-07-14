using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyIdleState : IState
{
    public BabyController baby { get; }

    public BabyIdleState(BabyController baby)
    {
        this.baby = baby;
    }

    public void Enter()
    {
        Debug.Log("Idle状態になりました！");
        this.baby.Animator.StartIdle();
    }

    public void Exit()
    {
        Debug.Log("Idle状態が終了しました！");
        this.baby.Animator.StopIdle();
    }
    public void Update()
    {
        Debug.Log("Idle状態です！");
        // idle状態というのはゲームの仕様上存在しないはずなので未実装
    }
}
