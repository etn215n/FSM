using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWalkState : FSMState 
{
	private Animator anim;
    private Rigidbody2D rb;
    private FreeMove freeMove;
    private int flip;
    private Vector2 currentDirection;
    private float timeCounter;

    public AIWalkState() : base()
    {
        this.stateID = StateID.Walk;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        freeMove = new FreeMove();
        freeMove.moveSpeed = 100f;
    }

    public override void OnStateEnter()
    {
    	flip++;
    	timeCounter = 0f;
        anim.SetInteger("StateID", 2);
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        anim.SetFloat("MoveX", currentDirection.x);
        anim.SetFloat("MoveY", currentDirection.y);
        timeCounter += Time.deltaTime;
    }

    public override void OnStateFixedUpdate()
    {
        freeMove.Move(currentDirection, rb);
    }

    public override void OnHandleInput()
    {
        if (flip % 2 == 0)
        	currentDirection = Vector2.right;
        else
			currentDirection = Vector2.left;

		if (timeCounter > 2f)
			SetTransition(Transition.ToIdle);
    }
}
