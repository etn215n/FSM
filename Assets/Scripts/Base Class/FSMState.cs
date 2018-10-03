using UnityEngine;

public class FSMState
{
    public FSM stateMachine;

    public virtual void OnStateEnter() {}
    public virtual void OnStateUpdate() {}
    public virtual void OnStateExit() {}
    public virtual void OnStateTransition(FSMState nextState)
    {
        if (nextState != null)
        {
            this.OnStateExit();
            stateMachine.SetState(nextState);
            nextState.OnStateEnter();
        }
    }
}
