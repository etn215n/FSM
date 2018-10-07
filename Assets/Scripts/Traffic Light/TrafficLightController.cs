using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour 
{
    private FSM trafficlightFSM;

    void Start()
    {
        trafficlightFSM = new FSM(this.gameObject);
        trafficlightFSM.AddState(new RedLightState());
        trafficlightFSM.AddState(new YellowLightState());
        trafficlightFSM.AddState(new GreenLightState());
        trafficlightFSM.Start();
    }

    void Update()
    {
        trafficlightFSM.Update();
    }
}
