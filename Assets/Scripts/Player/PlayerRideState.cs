using StateMachine;

public class PlayerRideState : FSMState
{
    public PlayerRideState()
    {
        this.stateID = StateID.Ride;
        transitionMap.Add(Transition.ToIdleRide, StateID.IdleRide);
        transitionMap.Add(Transition.ToUnequip, StateID.Unequip);
    }
    
    protected override void OnStateUpdate()
    {
        character.SetRideAnimation();
        OnHandleInput();
    }

    protected override void OnStateFixedUpdate()
    {
        character.Ride();
    }

    protected override void OnHandleInput()
    {
        if (character.ConditionToIdle() == true)
            SetTransition(Transition.ToIdleRide);
        else if (character.ConditionToUnequip() == true)
            SetTransition(Transition.ToUnequip);
    }
}
