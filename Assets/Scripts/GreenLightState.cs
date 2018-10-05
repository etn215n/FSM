using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLightState : FSMState
{
    public float timeCounter;
    public float timePool;
    private SpriteRenderer greenLight;

    public GreenLightState(FSM ownerFSM) : base(ownerFSM)
    {
        greenLight = ownerFSM.Character.transform.Find("Green Light").gameObject.GetComponent<SpriteRenderer>();
        this.stateID = StateID.Green;
        transitionMap.Add(Transition.ToYellow, StateID.Yellow);
        timePool = 3f;
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
