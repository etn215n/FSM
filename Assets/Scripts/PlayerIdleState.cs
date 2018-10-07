using UnityEngine;

public class PlayerIdleState : FSMState
{  
    private Animator anim;
    private CustomInput playerInput;
    private Rigidbody2D rb;
    private FreeMove freeMove;

    public PlayerIdleState() : base()
    { 
        this.stateID = StateID.Idle;
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        playerInput = ownerFSM.GetGameObject().GetComponent<PlayerController>().playerInput;
        freeMove = new FreeMove();
        freeMove.moveSpeed = 0f;
    }

    public override void OnStateEnter()
    {
        
        anim.SetInteger("StateID", 1);
        anim.SetFloat("LastMoveX", playerInput.currentAxis.x);
        anim.SetFloat("LastMoveY", playerInput.currentAxis.y);
        freeMove.Move(playerInput.currentAxis, rb);
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        freeMove.Move(playerInput.currentAxis, rb);
    }      

    public override void OnHandleInput()
    {
        if (playerInput.Get2DInput() != Vector2.zero)
            SetTransition(Transition.ToWalk);
    }
}
