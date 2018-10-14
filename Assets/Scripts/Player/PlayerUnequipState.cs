using UnityEngine;

public class PlayerUnequipState : FSMState 
{
    public PlayerUnequipState() : base()
    {
        this.stateID = StateID.Unequip;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
    }

    public override void OnStateEnter()
    {
        character.SetUnequipAnimation();  
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
    }

    public override void OnHandleInput()
    {
        SetTransition(Transition.ToIdle);
    }
}
