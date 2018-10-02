using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable FSM/Walk State")]
public class WalkState : FSMState
{
    public FSMState idleState;

    public override void OnStateEnter()
    {
        Debug.Log("Enter Walk");
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            OnStateTransition(idleState);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Walk");
    }
}