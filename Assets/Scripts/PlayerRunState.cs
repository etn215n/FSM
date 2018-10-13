using UnityEngine;

public class PlayerRunState : FSMState
{
    public PlayerRunState() : base()
    {
        this.stateID = StateID.Run;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToInteract, StateID.Interact);
    }

    public override void OnStateEnter()
    {
        character.SetRunAnimation();
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        character.UpdateRunAnimation();
    }

    public override void OnStateFixedUpdate()
    {
        character.Run();
    }

    public override void OnHandleInput()
    {
        if (character.ConditionToIdle() == false)
        {
            if (character.ConditionToNotRun() == true)
                SetTransition(Transition.ToWalk);
            else if (character.ConditionToInteract() == true)
                SetTransition(Transition.ToInteract);
        }
        else
            SetTransition(Transition.ToIdle);
    }
}
