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
        Debug.Log("Idle��ԂɂȂ�܂����I");
        this.baby.Animator.StartIdle();
    }

    public void Exit()
    {
        Debug.Log("Idle��Ԃ��I�����܂����I");
        this.baby.Animator.StopIdle();
    }
    public void Update()
    {
        Debug.Log("Idle��Ԃł��I");
        // idle��ԂƂ����̂̓Q�[���̎d�l�㑶�݂��Ȃ��͂��Ȃ̂Ŗ�����
    }
}
