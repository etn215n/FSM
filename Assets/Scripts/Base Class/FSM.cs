using UnityEngine;
using System.Collections.Generic;

public class FSM
{
    private List<FSMState> stateList;
    private FSMState currentState;
    private FSMState lastState;
    private GameObject gameObject;

    public FSM(GameObject gameObject)
    {
        stateList = new List<FSMState>();
        this.gameObject = gameObject;
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
        newState.SetFSM(this);
        newState.OnStateSetUp();
    } 

    public FSMState CurrentState
    {
        get { return currentState; }
    }

    public FSMState LastState
    {
        get { return lastState; }
    }

    public void Start()
    {
        currentState.OnStateEnter();
    }

    public void Update()
    {
        currentState.OnStateUpdate();
    }

    public void FixedUpdate()
    {
        currentState.OnStateFixedUpdate();
    }

    public void SetState(StateID stateID)
    {
        if (stateID == StateID.Null)
        {
            Debug.Log("Invalid State.");
            return;
        }

        foreach (FSMState state in stateList)
        {
            if (state.ID == stateID)
            {
                currentState.OnStateExit();
                lastState = currentState;
                currentState = state;
                currentState.OnStateEnter();
            }
        }
    }

    public GameObject GetGameObject() { return gameObject; }
}

