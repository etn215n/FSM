using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleRideState : FSMState
{
	public PlayerIdleRideState() : base()
	{
		this.stateID = StateID.IdleRide;
		transitionMap.Add(Transition.ToRide, StateID.Ride);
        transitionMap.Add(Transition.ToUnequip, StateID.Unequip);
	}
	
	public override void OnStateEnter()
	{
		character.SetIdleRideAnimation();
		character.Idle();
	}

	public override void OnStateUpdate()
    {
    	OnHandleInput();
    }

    public override void OnHandleInput()
    {
        if (character.ConditionToRide() == true)
            SetTransition(Transition.ToRide);
        else if (character.ConditionToUnequip() == true)
            SetTransition(Transition.ToUnequip);
    }
}
