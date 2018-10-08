using System.Collections.Generic;
using System;
using UnityEngine;

public class FSMState
{
    protected FSM ownerFSM;
    protected StateID stateID;
    protected Dictionary<Transition, StateID> transitionMap;

    public FSMState ()
    {
        transitionMap = new Dictionary<Transition, StateID>();
    }

    public StateID ID { get {return stateID;} }

    public void AddTransition(Transition transition, StateID stateID)
    {
        if (transition == Transition.Null)
        {
            Debug.Log("Invalid Transition.");
            return;
        }

        if (stateID == StateID.Null)
        {
            Debug.Log("Invalid State.");
            return;
        }

        if (transitionMap.ContainsKey(transition))
        {
            Debug.Log("State already contains this transition.");
            return;
        }

        transitionMap.Add(transition, stateID);
    }

    public void SetTransition(Transition transition)
    {
        if (transition == Transition.Null)
        {
            Debug.Log("Invalid Transition.");
            return;
        }

        if (!transitionMap.ContainsKey(transition))
        {
            Debug.Log("State does not contain this transition.");
            return;
        }
            
        ownerFSM.SetState(transitionMap[transition]);
    }

    public void SetFSM(FSM ownerFSM)
    {
        this.ownerFSM = ownerFSM;
    }
   
    public virtual void OnStateSetUp() {}
    public virtual void OnStateEnter() {}
    public virtual void OnStateUpdate() {}
    public virtual void OnStateFixedUpdate() {}
    public virtual void OnHandleInput() {}
    public virtual void OnStateExit() {}
}
