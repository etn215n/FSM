using UnityEngine;

public class PlayerRunState : FSMState
{
    private Animator anim;
    private CustomInput playerInput;
    private Rigidbody2D rb;
    private FreeMove freeMove;

    public PlayerRunState() : base()
    {
        this.stateID = StateID.Run;
        transitionMap.Add(Transition.ToIdle, StateID.Idle);
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
        playerInput = ownerFSM.GetGameObject().GetComponent<PlayerController>().playerInput;
        freeMove = new FreeMove();
        freeMove.moveSpeed = 300f;
    }

    public override void OnStateEnter()
    {
        anim.SetInteger("StateID", 3);
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
        if (playerInput.Get2DInput() != Vector2.zero)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
                SetTransition(Transition.ToWalk);
        }
        else
            SetTransition(Transition.ToIdle);
    }
}
