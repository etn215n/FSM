using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightState : FSMState
{
    public float timeCounter;
    public float timePool;
    private SpriteRenderer redLight;

    public RedLightState(FSM ownerFSM) : base(ownerFSM)
    {
        redLight = ownerFSM.Character.transform.Find("Red Light").gameObject.GetComponent<SpriteRenderer>();
        this.stateID = StateID.Red;
        transitionMap.Add(Transition.ToYellow, StateID.Yellow);
        timePool = 3f;
    }

    public override void OnStateEnter()
    {
        timeCounter = 0f;
        redLight.color = Color.red;
    }

    public override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= timePool)
            SetTransition(Transition.ToYellow);
    }

    public override void OnStateExit()
    {
        redLight.color = Color.white;
    }
}
