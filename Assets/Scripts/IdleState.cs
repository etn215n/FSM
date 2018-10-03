using UnityEngine;

public class IdleState : FSMState
{
    public FSMState walkState;

    private float time;
    private float timeCounter;

    public override void OnStateEnter()
    {
        Debug.Log("Enter Idle");
        time = 2f;
        timeCounter = 0f;
    }

    public override void OnStateUpdate()
    {
        if (timeCounter > time)
        {
            if (Input.GetKey(KeyCode.Space))
                OnStateTransition(walkState);
        }
        else
            timeCounter += Time.deltaTime;
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Idle");
    }
}
