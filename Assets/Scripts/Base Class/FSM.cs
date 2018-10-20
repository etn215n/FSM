using UnityEngine;
using System.Collections.Generic;

public class FSM
{
    private List<FSMState> stateList;
    private FSMState currentState;
    private FSMState lastState;
    private readonly Character character;

    public FSMState CurrentState { get { return currentState; } }
    public FSMState LastState    { get { return lastState;    } }

    public FSM(Character character)
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
        foreach(FSMState state in stateList)
        {
            if (state.ID == newState.ID)
            {
                Debug.Log("FSM already contains this state.");
                return;
            }
        }

        if (stateList.Count == 0)
        {
            currentState = newState;
        }

        stateList.Add(newState);
        newState.SetFSM(this);
        newState.SetCharacter(this.character);
    } 

    public void SetState(StateID stateID)
    {
        foreach (FSMState state in stateList)
        {
            if (state.ID == stateID)
            {
                currentState.OnStateExit();
                lastState = currentState;
                currentState = state;
                currentState.OnStateEnter();
                return;
            }
        }

        Debug.Log("Invalid state or state does not belong to this FSM.");
    }

    public void SetEntryState(StateID stateID)
    {
        foreach (FSMState state in stateList)
        {
            if (state.ID == stateID)
            {
                currentState = state;
                return;
            }
        }

        Debug.Log("Invalid state or state does not belong to this FSM.");
    }

    public void Start()       { currentState.OnStateEnter();       }
    public void Update()      { currentState.OnStateUpdate();      }
    public void FixedUpdate() { currentState.OnStateFixedUpdate(); }
}
