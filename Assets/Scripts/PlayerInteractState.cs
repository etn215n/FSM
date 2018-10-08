using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : FSMState
{
    private Animator anim;
    private CustomInput playerInput;
    private float timeCounter;
    private Rigidbody2D rb;

    public PlayerInteractState() : base()
    { 
        this.stateID = StateID.Interact;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }

    public override void OnStateSetUp()
    {
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        playerInput = ownerFSM.GetGameObject().GetComponent<PlayerController>().playerInput;
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
    }

    public override void OnStateEnter()
    {
        int mylayerMask = 1 << 10;
        RaycastHit2D hit = Physics2D.Raycast(ownerFSM.GetGameObject().transform.position, playerInput.savedAxis, 20, mylayerMask);

        if (hit != null && hit.collider != null && hit.collider.tag == "Collectible")
        {
            GameObject.Destroy(hit.collider.gameObject);
        }
        
        rb.velocity = Vector2.zero;
        timeCounter = 0f;
        anim.SetInteger("StateID", 4);
        anim.SetFloat("LastMoveX", playerInput.savedAxis.x);
        anim.SetFloat("LastMoveY", playerInput.savedAxis.y);
    }

    public override void OnStateUpdate()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter > 0.5f)
            ownerFSM.SetState(ownerFSM.LastState.ID);
    }      
}
