using System.Collections.Generic;
using System;
using UnityEngine;

namespace StateMachine
{
    public class FSMState
    {
        protected FSM ownerFSM;
        protected StateID stateID;
        protected Dictionary<Transition, StateID> transitionMap;
        protected Character character;

        public FSMState ()
        {
            transitionMap = new Dictionary<Transition, StateID>();
        }
        public FSMState (StateID stateID)
        {
            this.stateID = stateID;
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
        protected void SetTransition(Transition transition)
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
        protected void TransitionToLastState()
        {
            ownerFSM.SetState(ownerFSM.LastState.ID);
        }

        internal void SetFSM(FSM ownerFSM)
        {
            this.ownerFSM = ownerFSM;
        }
        internal void SetCharacter(Character character)
        {
            this.character = character;
        }

        protected internal virtual void OnStateEnter() {}
        protected internal virtual void OnStateUpdate() {}
        protected internal virtual void OnStateFixedUpdate() {}
        protected internal virtual void OnHandleInput() {}
        protected internal virtual void OnStateExit() {}
    }
}