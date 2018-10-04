using UnityEngine;
using System.Collections.Generic;

public class FSM
{
    private List<FSMState> stateList;
    private FSMState currentState;
    private GameObject character;

    public FSM(GameObject character)
    {
        stateList = new List<FSMState>();
        this.character = character;
    }

    public void AddState(FSMState newState)
    {
        if (newState.ID == StateID.Null)
        {
            Debug.Log("Invalid State.");
            return;
        }

        if (stateList.Count == 0)
        {
            currentState = newState;
        }

        foreach(FSMState state in stateList)
        {
            if (state.ID == newState.ID)
            {
                Debug.Log("FSM already contains this state.");
                return;
            }
        }

        stateList.Add(newState);
    } 

    public FSMState CurrentState
    {
        get { return currentState; }
    }

    public void Update()
    {
        currentState.OnStateUpdate();
    }

    public void SetState(StateID nextStateID)
    {
        if (nextStateID == StateID.Null)
        {
            Debug.Log("Invalid State.");
            return;
        }

        foreach (FSMState state in stateList)
        {
            if (state.ID == nextStateID)
            {
                currentState.OnStateExit();
                currentState = state;
                currentState.OnStateEnter();
            }
        }
    }
}

