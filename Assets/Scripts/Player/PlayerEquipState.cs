using UnityEngine;

public class PlayerEquipState : FSMState 
{
    public PlayerEquipState() : base()
    {
        this.stateID = StateID.Equip;
        transitionMap.Add(Transition.ToIdleRide, StateID.IdleRide);
    }

    public override void OnStateEnter()
    {
    	character.SetEquipAnimation();	
    }

    public override void OnStateUpdate()
    {
    	OnHandleInput();
    }

    public override void OnHandleInput()
    {
    	if (character.ConditionToIdleRide() == true)
    		SetTransition(Transition.ToIdleRide);
    }
}
