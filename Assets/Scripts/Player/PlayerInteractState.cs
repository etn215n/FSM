using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : FSMState
{
    private float timeCounter;

    public PlayerInteractState() : base()
    { 
        this.stateID = StateID.Interact;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }
        
    public override void OnStateEnter()
    {
        character.Interact();
        character.SetInteractAnimation();
        timeCounter = 0f;
    }

    public override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter > 0.5f)
            ownerFSM.SetState(ownerFSM.LastState.ID);
    }      
}
