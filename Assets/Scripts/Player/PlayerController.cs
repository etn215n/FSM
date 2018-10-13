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
        brendan.animator = GetComponent<Animator>();
        brendan.customInput = playerInput;
        brendan.rigidboby2d = GetComponent<Rigidbody2D>();
        brendan.transform = GetComponent<Transform>();

        playerFSM = new FSM(brendan);
        playerFSM.AddState(new PlayerIdleState());
        playerFSM.AddState(new PlayerWalkState());
        playerFSM.AddState(new PlayerRunState());
        playerFSM.AddState(new PlayerInteractState());
        playerFSM.AddState(new PlayerEquipState());
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
