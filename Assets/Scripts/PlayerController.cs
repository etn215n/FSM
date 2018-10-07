using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private FSM playerFSM;
    public CustomInput playerInput;

    void Start()
    {
        playerInput = new CustomInput();
        playerFSM = new FSM(this.gameObject);
        playerFSM.AddState(new PlayerIdleState());
        playerFSM.AddState(new PlayerWalkState());
        playerFSM.AddState(new PlayerRunState());
        playerFSM.Start();
    }

    void Update()
    {
        playerFSM.Update();
    }
    
}
