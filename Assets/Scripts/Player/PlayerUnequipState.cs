using StateMachine;

public class PlayerUnequipState : FSMState 
{
    public PlayerUnequipState()
    {
        this.stateID = StateID.Unequip;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
    }

    protected override void OnStateEnter()
    {
        character.SetUnequipAnimation();  
    }

    protected override void OnStateUpdate()
    {
        OnHandleInput();
    }

    protected override void OnHandleInput()
    {
        SetTransition(Transition.ToIdle);
    }
}
