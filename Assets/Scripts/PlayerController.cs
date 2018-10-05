using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private FSM playerFSM;


    void Start()
    {
        playerFSM = new FSM(this.gameObject);
        playerFSM.AddState(new PlayerIdleState(playerFSM));
        playerFSM.AddState(new PlayerWalkState(playerFSM));
    }

    void Update()
    {
        playerFSM.Update();
    }
}
