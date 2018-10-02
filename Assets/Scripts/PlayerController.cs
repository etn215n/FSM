using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public FSM playerFSM;

    void Start()
    {
        playerFSM.subject = this.gameObject;
        playerFSM.Start();
    }

    void Update()
    {
        playerFSM.Update();
    }
}
