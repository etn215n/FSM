using UnityEngine;

public class PlayerWalkState : FSMState
{  
    public PlayerWalkState(FSM ownerFSM) : base(ownerFSM)
    {
        this.stateID = StateID.Walk;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter Walk");
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKey(KeyCode.S))
            SetTransition(Transition.ToIdle);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Walk");
    }

}
