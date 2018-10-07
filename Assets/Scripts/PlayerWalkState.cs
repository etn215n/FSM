﻿using UnityEngine;

public class PlayerWalkState : FSMState
{  
    private Animator anim;
    private CustomInput playerInput;
    private Rigidbody2D rb;
    private FreeMove freeMove;

    public PlayerWalkState() : base()
    {
        this.stateID = StateID.Walk;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        playerInput = ownerFSM.GetGameObject().GetComponent<PlayerController>().playerInput;
        freeMove = new FreeMove();
        freeMove.moveSpeed = 100f;
    }

    public override void OnStateEnter()
    {
        anim.SetInteger("StateID", 2);
        anim.SetFloat("MoveX", playerInput.currentAxis.x);
        anim.SetFloat("MoveY", playerInput.currentAxis.y);
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        anim.SetFloat("MoveX", playerInput.currentAxis.x);
        anim.SetFloat("MoveY", playerInput.currentAxis.y);
        freeMove.Move(playerInput.currentAxis, rb);
    }

    public override void OnHandleInput()
    {
        if (playerInput.Get2DInput() == Vector2.zero)
            SetTransition(Transition.ToIdle);
        
        if (Input.GetKey(KeyCode.LeftShift))
            SetTransition(Transition.ToRun);
    }
}
