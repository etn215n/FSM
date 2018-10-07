using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightState : FSMState
{
    public float timeCounter;
    public float timePool;
    private SpriteRenderer redLight;

    public RedLightState() : base()
    { 
        this.stateID = StateID.Red;
        transitionMap.Add(Transition.ToYellow, StateID.Yellow);
        timePool = 1f;
    }

    public override void OnStateSetUp()
    {
        redLight = ownerFSM.GetGameObject().transform.Find("Red Light").gameObject.GetComponent<SpriteRenderer>();
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
