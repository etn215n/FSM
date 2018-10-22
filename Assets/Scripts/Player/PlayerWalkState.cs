using StateMachine;

public class PlayerWalkState : FSMState
{  
    public PlayerWalkState()
    {
        this.stateID = StateID.Walk;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToRun, StateID.Run);
        transitionMap.Add(Transition.ToInteract, StateID.Interact);
        transitionMap.Add(Transition.ToEquip, StateID.Equip);
    }

    protected override void OnStateUpdate()
    {
        character.SetWalkAnimation();
        OnHandleInput();
    }

    protected override void OnStateFixedUpdate()
    {
        character.Walk();
    }

    protected override void OnHandleInput()
    {
        if (character.ConditionToIdle() == true)
            SetTransition(Transition.ToIdle);  
        else if (character.ConditionToRun() == true)
            SetTransition(Transition.ToRun);
        else if (character.ConditionToInteract() == true)
            SetTransition(Transition.ToInteract);
        else if (character.ConditionToEquip() == true)
            SetTransition(Transition.ToEquip);
    }
}
