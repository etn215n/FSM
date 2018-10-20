﻿using UnityEngine;

public class PlayerRideState : FSMState
{
    public PlayerRideState() : base()
    {
        this.stateID = StateID.Ride;
        transitionMap.Add(Transition.ToIdleRide, StateID.IdleRide);
        transitionMap.Add(Transition.ToUnequip, StateID.Unequip);
    }
    
    public override void OnStateUpdate()
    {
        character.SetRideAnimation();
        OnHandleInput();
    }

    public override void OnStateFixedUpdate()
    {
        character.Ride();
    }

    public override void OnHandleInput()
    {
        if (character.ConditionToIdle() == true)
            SetTransition(Transition.ToIdleRide);
        else if (character.ConditionToUnequip() == true)
            SetTransition(Transition.ToUnequip);
    }
}
