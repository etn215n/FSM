using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour 
{
	private FSM aiFSM;

    void Start()
    {
        aiFSM = new FSM(this.gameObject);
        aiFSM.AddState(new AIIdleState());
        aiFSM.AddState(new AIWalkState());
        aiFSM.Start();
    }

    void Update()
    {
        aiFSM.Update();
    }

    void FixedUpdate()
    {
        aiFSM.FixedUpdate();
    }
}
