using UnityEngine;

public class AIIdleState : FSMState
{
	private Animator anim;
    private Rigidbody2D rb;
    private float timeCounter;

    public AIIdleState() : base()
    { 
        this.stateID = StateID.Idle;
        transitionMap.Add(Transition.ToWalk, StateID.Walk);
        transitionMap.Add(Transition.ToRun, StateID.Run);
    }

    public override void OnStateSetUp()
    {
        rb = ownerFSM.GetGameObject().GetComponent<Rigidbody2D>();
        anim = ownerFSM.GetGameObject().GetComponent<Animator>();
    }

    public override void OnStateEnter()
    {
        anim.SetInteger("StateID", 1);
        anim.SetFloat("LastMoveX", 1f);
        anim.SetFloat("LastMoveY", 0f);
        rb.velocity = Vector2.zero;
        timeCounter = 0f;
    }

    public override void OnStateUpdate()
    {
        OnHandleInput();
        timeCounter += Time.deltaTime;
    }      

    public override void OnHandleInput()
    {
        if (timeCounter > 1f)
            SetTransition(Transition.ToWalk);
    }
}
