using System.Collections;
using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public BabyCrawlState crawlState;
    public BabyIdleState idleState;
    public BabyRattleState rattleState;
    public BabyTissueState tissueState;
    public BabyBottleState bottleState;
    public BabyWalkerState walkerState;
    public BabyMicState micState;
    public BabyCarState carState;

    public StateMachine(BabyController baby)
    {
        this.crawlState = new BabyCrawlState(baby);
        this.idleState = new BabyIdleState(baby);
        this.rattleState = new BabyRattleState(baby);
        this.tissueState = new BabyTissueState(baby);
        this.bottleState = new BabyBottleState(baby);
        this.walkerState = new BabyWalkerState(baby);
        this.micState = new BabyMicState(baby);
        this.carState = new BabyCarState(baby);
    }

    public void Initialize(IState state)
    {
        this.currentState = state;
        state.Enter();
    }

    public void Update()
    {
        if (this.currentState != null)
        {
            this.currentState.Update();
        }
    }

    public IState CurrentState()
    {
        return this.currentState;
    }

    public void TransitionTo(IState newState)
    {


        if (this.currentState == newState) { return; }

        this.currentState.Exit();
        this.currentState = newState;

        newState.Enter();
    }
}
