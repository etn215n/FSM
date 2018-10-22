using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class PlayerController : MonoBehaviour 
{
    private FSM playerFSM;
    private BrendanCharacter brendan;

    void Start()
    {
        brendan = new BrendanCharacter();
        
        brendan.SetAnimator(GetComponent<Animator>());
        brendan.Set2DRigidbody(GetComponent<Rigidbody2D>());
        brendan.SetTransform(GetComponent<Transform>());
        brendan.SetInput(new CustomInput());

        playerFSM = new FSM(brendan);
        playerFSM.AddState(new PlayerIdleState());
        playerFSM.AddState(new PlayerWalkState());
        playerFSM.AddState(new PlayerRunState());
        playerFSM.AddState(new PlayerInteractState());
        playerFSM.AddState(new PlayerEquipState());
        playerFSM.AddState(new PlayerIdleRideState());
        playerFSM.AddState(new PlayerRideState());
        playerFSM.AddState(new PlayerUnequipState());
        playerFSM.Start();
    }

    void Update()
    {
        playerFSM.Update();
    }

    void FixedUpdate()
    {
        playerFSM.FixedUpdate();
    }
}
