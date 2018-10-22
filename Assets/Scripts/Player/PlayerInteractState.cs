using UnityEngine;
using StateMachine;

public class PlayerInteractState : FSMState
{
    private float timeCounter;

    public PlayerInteractState()
    { 
        this.stateID = StateID.Interact;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }
        
    protected override void OnStateEnter()
    {
        character.Interact();
        character.SetInteractAnimation();
        timeCounter = 0f;
    }

    protected override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter > 0.5f)
            TransitionToLastState();
    }      
}
