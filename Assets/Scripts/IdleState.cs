using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable FSM/Idle State")]
public class IdleState : FSMState
{
    public FSMState walkState;

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Idle");
    }
}
