using UnityEngine;
using StateMachine;

public class BotCharacter : Character
{
    private float walkSpeed = 100f;
    private float runSpeed = 200f;

    public override void SetIdleAnimation()
    {
        animator.SetInteger("StateID", 1);
        animator.SetFloat("LastMoveX", customInput.savedAxis.x);
        animator.SetFloat("LastMoveY", customInput.savedAxis.y);
    }

    public override void SetWalkAnimation() // Need improvement
    {
        animator.SetInteger("StateID", 2);
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override void SetRunAnimation()
    {
        animator.SetInteger("StateID", 3);
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }
        

    public override bool ConditionToWalk()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) < 1f)
            return true;

        return false;
    }

    public override bool ConditionToIdle()
    {
        if (ConditionToWalk() == false)
            return true;

        return false;
    }

    public override void Idle()
    {
        rigidboby2d.velocity = Vector2.zero;
    }

    public override void Walk()
    {
        Vector3 toward3d = target.transform.position - this.transform.position;
        Vector2 toward2d = new Vector2(toward3d.x, toward3d.y);


        rigidboby2d.velocity = toward2d * walkSpeed * Time.deltaTime;
    }

    public override void Run()
    {
        rigidboby2d.velocity = customInput.currentAxis * runSpeed * Time.deltaTime;
    }
}
