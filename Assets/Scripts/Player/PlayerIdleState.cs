﻿using UnityEngine;

public class PlayerIdleState : FSMState
{  
    public PlayerIdleState() : base()
    { 
        this.stateID = StateID.Idle;
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
        transitionMap.Add(Transition.ToInteract, StateID.Interact);
        transitionMap.Add(Transition.ToEquip, StateID.Equip);
    }
       
    public override void OnStateEnter()
    {
        character.SetIdleAnimation();
        character.Idle();
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
    }      

    public override void OnHandleInput()
    {
        if (character.ConditionToWalk() == true)
            SetTransition(Transition.ToWalk);
        else if (character.ConditionToInteract() == true)
            SetTransition(Transition.ToInteract);
        else if (character.ConditionToEquip() == true)
            SetTransition(Transition.ToEquip);
    }
}
