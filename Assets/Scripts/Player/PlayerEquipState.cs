using StateMachine;

public class PlayerEquipState : FSMState 
{
    public PlayerEquipState()
    {
        this.stateID = StateID.Equip;
        transitionMap.Add(Transition.ToIdleRide, StateID.IdleRide);
    }

    protected override void OnStateEnter()
    {
    	character.SetEquipAnimation();	
    }

    protected override void OnStateUpdate()
    {
    	OnHandleInput();
    }

    protected override void OnHandleInput()
    {
    	if (character.ConditionToIdleRide() == true)
    		SetTransition(Transition.ToIdleRide);
    }
}
