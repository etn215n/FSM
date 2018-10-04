using UnityEngine;

public class PlayerIdleState : FSMState
{  
    public PlayerIdleState(FSM ownerFSM) : base(ownerFSM)
    {
        this.stateID = StateID.Idle;
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter Idle");
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            SetTransition(Transition.ToWalk);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Idle");
    }

}
