using UnityEngine;
using System.Collections.Generic;

namespace StateMachine
{
    public class FSM
    {
        protected internal delegate void FunctionSelector();
        private readonly Character character;
        private List<FSMState> stateList;
        private FSMState currentState;
        private FSMState lastState;
        private bool isStarted;
        private FunctionSelector update;
        private FunctionSelector fixedupdate;
        /*-------------------------------------------------------------------------*/
        private void EmptyFunction() {}
        /*-------------------------------------------------------------------------*/
        public FSM(Character character)
        {
            stateList = new List<FSMState>();
            this.character = character;
        }

        public FSMState CurrentState { get { return currentState; } }
        public FSMState LastState    { get { return lastState;    } }
        /*-------------------------------------------------------------------------*/
        public void Start()       
        { 
            if (stateList.Count == 0)
            {
                Debug.Log("There is no state in this FSM.");
                return;
            }

            update      = currentState.OnStateUpdate;      
            fixedupdate = currentState.OnStateFixedUpdate;

            isStarted = true;
            currentState.OnStateEnter();       
        }

        /*public void Resume()
        {
            update      = currentState.OnStateUpdate;
            fixedupdate = currentState.OnStateFixedUpdate;
        }

        public void Pause()
        {
            currentState.OnStatePaused();

            update      = EmptyFunction;
            fixedupdate = EmptyFunction;
        }*/

        public void Update()      
        { 
            update();    
        }

        public void FixedUpdate() 
        { 
            fixedupdate();
        }
        /*-------------------------------------------------------------------------*/
        public void AddState(FSMState newState)
        {
            if (newState.ID == StateID.Null)
            {
                Debug.Log("Invalid State.");
                return;
            }
            foreach (FSMState state in stateList)
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
        /*-------------------------------------------------------------------------*/
        internal void SetState(StateID stateID)
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
        /*-------------------------------------------------------------------------*/
    }
}
