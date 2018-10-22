using StateMachine;

public class PlayerIdleRideState : FSMState
{
	public PlayerIdleRideState()
	{
		this.stateID = StateID.IdleRide;
		transitionMap.Add(Transition.ToRide, StateID.Ride);
        transitionMap.Add(Transition.ToUnequip, StateID.Unequip);
	}
	
	protected override void OnStateEnter()
	{
		character.SetIdleRideAnimation();
		character.Idle();
	}

    protected override void OnStateUpdate()
    {
    	OnHandleInput();
    }

    protected override void OnHandleInput()
    {
        if (character.ConditionToRide() == true)
            SetTransition(Transition.ToRide);
        else if (character.ConditionToUnequip() == true)
            SetTransition(Transition.ToUnequip);
    }
}
