using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(BabyMover))]
[RequireComponent(typeof(BabyAnimator))]
[RequireComponent(typeof(BabyStatus))]

public class BabyController : MonoBehaviour, IBabyStateChangeable
{
    private BabyMover mover;
    public BabyMover Mover
    {
        get { return this.mover; }
    }

    private BabyAnimator animator;
    public BabyAnimator Animator
    {
        get { return this.animator; }
    }

    private BabyStatus status;
    public BabyStatus Status
    {
        get { return this.status; }
    }

    private StateMachine stateMachine;
    public StateMachine StateMachine
    {
        get { return this.stateMachine; }
    }

    // private Rigidbody2D rb2d;
    private CapsuleCollider2D _cc2d;

    public event Action<IStockable> onStackableItemCollision;
    public event Action<Item> onItemCollision;

    private void Start()
    {
        this.GetRequiredComponents();

        this.stateMachine = new StateMachine(this);
        this.stateMachine.Initialize(this.stateMachine.crawlState);

        transform.rotation = Quaternion.Euler(0, 0, this.status.GetInitialAngle());
    }

    private void GetRequiredComponents()
    {
        this.mover = this.GetComponent<BabyMover>();
        this.animator = this.GetComponent<BabyAnimator>();
        this.status = this.GetComponent<BabyStatus>();
        _cc2d = this.GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        IState currentState = this.stateMachine.CurrentState();

        if (item != null && currentState == this.stateMachine.crawlState)
        {
            this.onItemCollision?.Invoke(item);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        float currentSpeed = this.status.GetCurrentSpeed();
        this.mover.MoveForward(currentSpeed);
    }

    public void ChangeBabyState(BabyState babyState, float effectTime)
    {
        StartCoroutine(ReturnToDefaultState(effectTime));

        /*
        if (babyState != BabyState.Crawl || babyState != BabyState.Walker || babyState != BabyState.Car)
        {
            _cc2d.enabled = false;
        }
        else
        {
            _cc2d.enabled = true;
        }
        */

        switch (babyState)
        {
            case BabyState.Crawl:
                this.stateMachine.TransitionTo(this.stateMachine.crawlState);
                break;
            case BabyState.Rattle:
                this.stateMachine.TransitionTo(this.stateMachine.rattleState);
                this.Animator.RotateToOriginal(effectTime);
                break;
            case BabyState.Bottle:
                this.stateMachine.TransitionTo(this.stateMachine.bottleState);
                this.Animator.RotateToOriginal(effectTime);
                break;
            case BabyState.Tissue:
                this.stateMachine.TransitionTo(this.stateMachine.tissueState);
                this.Animator.RotateToOriginal(effectTime);
                break;
            case BabyState.Mic:
                this.stateMachine.TransitionTo(this.stateMachine.micState);
                this.Animator.RotateToOriginal(effectTime);
                break;
            case BabyState.Walker:
                this.stateMachine.TransitionTo(this.stateMachine.walkerState);
                break;
            case BabyState.Car:
                this.stateMachine.TransitionTo(this.stateMachine.carState);
                break;
        }
    }

    public bool IsCrawling()
    {
        IState currentState = this.stateMachine.CurrentState();
        return currentState == this.stateMachine.crawlState;
    }

    IEnumerator ReturnToDefaultState(float time)
    {
        yield return new WaitForSeconds(time);
        this.stateMachine.TransitionTo(this.stateMachine.crawlState);
    } 
}

public enum BabyState {
    Crawl,
    Rattle,
    Bottle,
    Tissue,
    Walker,
    Car,
    Mic
}
