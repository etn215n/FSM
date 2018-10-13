using UnityEngine;

public class PlayerWalkState : FSMState
{  
    public PlayerWalkState() : base()
    {
        this.stateID = StateID.Walk;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToRun, StateID.Run);
        transitionMap.Add(Transition.ToInteract, StateID.Interact);
    }
        
    public override void OnStateEnter()
    {
        character.SetWalkAnimation();
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        character.UpdateWalkAnimation();
    }

    public override void OnStateFixedUpdate()
    {
        character.Walk();
    }

    public override void OnHandleInput()
    {
        if (character.ConditionToIdle() == true)
            SetTransition(Transition.ToIdle);  
        else if (character.ConditionToRun() == true)
            SetTransition(Transition.ToRun);
        else if (character.ConditionToInteract() == true)
            SetTransition(Transition.ToInteract);
    }
}
