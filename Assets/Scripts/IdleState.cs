using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable FSM/Idle State")]
public class IdleState : FSMState
{
    public FSMState walkState;

    public override void OnStateEnter()
    {
        Debug.Log("Enter Idle");
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            OnStateTransition(walkState);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Idle");
    }
}
