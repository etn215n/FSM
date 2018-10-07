using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLightState : FSMState
{
    public float timeCounter;
    public float timePool;
    private SpriteRenderer greenLight;

    public GreenLightState() : base()
    {
        this.stateID = StateID.Green;
        transitionMap.Add(Transition.ToYellow, StateID.Yellow);
        timePool = 1f;
    }

    public override void OnStateSetUp()
    {
        greenLight = ownerFSM.GetGameObject().transform.Find("Green Light").gameObject.GetComponent<SpriteRenderer>();
    }

    public override void OnStateEnter()
    {
        timeCounter = 0f;
        greenLight.color = Color.green;
    }

    public override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= timePool)
            SetTransition(Transition.ToYellow);
    }

    public override void OnStateExit()
    {
        greenLight.color = Color.white;
    }
}
