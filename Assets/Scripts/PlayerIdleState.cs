using UnityEngine;

public class PlayerIdleState : FSMState
{  
    private Animator anim;
    private CustomInput playerInput;
    private Rigidbody2D rb;

    public PlayerIdleState() : base()
    { 
        this.stateID = StateID.Idle;
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
        transitionMap.Add(Transition.ToInteract, StateID.Interact);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        playerInput = ownerFSM.GetGameObject().GetComponent<PlayerController>().playerInput;
    }

    public override void OnStateEnter()
    {
        anim.SetInteger("StateID", 1);
        anim.SetFloat("LastMoveX", playerInput.savedAxis.x);
        anim.SetFloat("LastMoveY", playerInput.savedAxis.y);
        rb.velocity = Vector2.zero;
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
    }      

    public override void OnHandleInput()
    {
        if (playerInput.Get2DInput() != Vector2.zero)
            SetTransition(Transition.ToWalk);
        else if (Input.GetKey(KeyCode.E))
            SetTransition(Transition.ToInteract);
    }
}
