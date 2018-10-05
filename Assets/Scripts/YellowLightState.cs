using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLightState : FSMState
{
    public float timeCounter;
    public float timePool;
    private SpriteRenderer yellowLight;

    public YellowLightState(FSM ownerFSM) : base(ownerFSM)
    {
        yellowLight = ownerFSM.Character.transform.Find("Yellow Light").gameObject.GetComponent<SpriteRenderer>();
        this.stateID = StateID.Yellow;
        transitionMap.Add(Transition.ToGreen, StateID.Green);
        transitionMap.Add(Transition.ToRed, StateID.Red);
        timePool = 1.5f;
    }

    public override void OnStateEnter()
    {
        timeCounter = 0f;
        yellowLight.color = Color.yellow;
    }

    public override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= timePool)
        {
            switch (ownerFSM.LastState.ID)
            {
                case StateID.Red:
                    SetTransition(Transition.ToGreen);
                    break;

                case StateID.Green:
                    SetTransition(Transition.ToRed);
                    break;
            }
        }
    }

    public override void OnStateExit()
    {
        yellowLight.color = Color.white;
    }
}
