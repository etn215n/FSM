using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour 
{
    private FSM trafficlightController;

    void Start()
    {
        trafficlightController = new FSM(this.gameObject);
        trafficlightController.AddState(new RedLightState(trafficlightController));
        trafficlightController.AddState(new YellowLightState(trafficlightController));
        trafficlightController.AddState(new GreenLightState(trafficlightController));
        trafficlightController.Start();
    }

    void Update()
    {
        trafficlightController.Update();
    }
}
