using UnityEngine;

public class FSM :ScriptableObject
{
    public FSMState entryState;

    [HideInInspector]
    public GameObject subject;

    private FSMState currentState;

    public void Start()
    {
        currentState = entryState;
    }

    public void Update()
    {
        currentState.OnStateUpdate();
    }

    public void SetState(FSMState state)
    {
        if (state != null)
            currentState = state;
    }
}

