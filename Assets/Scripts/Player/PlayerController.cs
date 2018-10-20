using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private FSM playerFSM;
    private CustomInput playerInput;
    private BrendanCharacter brendan;
    private Transform transform;

    void Start()
    {
        playerInput = new CustomInput();
        brendan = new BrendanCharacter();
        
        brendan.SetAnimator(GetComponent<Animator>());
        brendan.Set2DRigidbody(GetComponent<Rigidbody2D>());
        brendan.SetTransform(GetComponent<Transform>());
        brendan.SetInput(playerInput);

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
