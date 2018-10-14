using UnityEngine;

public class BrendanCharacter : Character
{
    private float walkSpeed = 100f;
    private float runSpeed = 200f;
    private float rideSpeed = 300f;
    private int equipedItemID = 0;

    public override void SetIdleAnimation()
    {
        animator.SetInteger("StateID", (int)StateID.Idle);
        animator.SetFloat("LastMoveX", customInput.savedAxis.x);
        animator.SetFloat("LastMoveY", customInput.savedAxis.y);
    }

    public override void SetWalkAnimation() // Need improvement
    {
        animator.SetInteger("StateID", (int)StateID.Walk);
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override void UpdateWalkAnimation() // Need improvement
    {
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override void SetRunAnimation()
    {
        animator.SetInteger("StateID", (int)StateID.Run);
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override void UpdateRunAnimation()
    {
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override void SetInteractAnimation()
    {
        animator.SetInteger("StateID", (int)StateID.Interact);
        animator.SetFloat("LastMoveX", customInput.savedAxis.x);
        animator.SetFloat("LastMoveY", customInput.savedAxis.y);
    }

    public override void SetEquipAnimation() 
    {
        animator.SetInteger("StateID", (int)StateID.Equip);
    }

    public override void SetUnequipAnimation() 
    {
        animator.SetInteger("StateID", (int)StateID.Unequip);
    }

    public override void SetIdleRideAnimation()
    {
        animator.SetInteger("StateID", (int)StateID.IdleRide);
        animator.SetFloat("LastMoveX", customInput.savedAxis.x);
        animator.SetFloat("LastMoveY", customInput.savedAxis.y);
    }

    public override void SetRideAnimation()
    {
        animator.SetInteger("StateID", (int)StateID.Ride);
    }

    public override void UpdateRideAnimation()
    {
        animator.SetFloat("MoveX", customInput.currentAxis.x);
        animator.SetFloat("MoveY", customInput.currentAxis.y);
    }

    public override bool ConditionToWalk()
    {
        if (customInput.Get2DInput() != Vector2.zero)
            return true;

        return false;
    }

    public override bool ConditionToRide()
    {
        if (customInput.Get2DInput() != Vector2.zero)
            return true;

        return false;
    }

    public override bool ConditionToIdle()
    {
        if (customInput.Get2DInput() == Vector2.zero)
            return true;

        return false;
    }

    public override bool ConditionToRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return true;

        return false;
    }

    public override bool ConditionToNotRun()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
            return true;

        return false;
    }

    public override bool ConditionToInteract()
    {
        if (Input.GetKey(KeyCode.E))
            return true;

        return false;
    }

    public override bool ConditionToEquip()
    {
        int itemID = customInput.GetInventoryInput();

        //TODO: implement inventory checking

        if (itemID == -1)
            return false;
        else
        {
            equipedItemID = itemID;
            return true;
        }
    }

    public override bool ConditionToUnequip()
    {
        if (Input.GetKey(KeyCode.X))
            return true;

        return false;
    }

    public override bool ConditionToIdleRide()
    {
        if (equipedItemID == 1)
            return true;

        return false;
    }

    public override void Idle()
    {
        rigidboby2d.velocity = Vector2.zero;
    }

    public override void Walk()
    {
        rigidboby2d.velocity = customInput.currentAxis * walkSpeed * Time.deltaTime;
    }

    public override void Run()
    {
        rigidboby2d.velocity = customInput.currentAxis * runSpeed * Time.deltaTime;
    }

    public override void Ride()
    {
        rigidboby2d.velocity = customInput.currentAxis * rideSpeed * Time.deltaTime;
    }

    public override void Interact()
    {
        this.Idle();
        this.PickUp();
    }

    public override void PickUp() 
    {
        int mylayerMask = 1 << 10;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, customInput.savedAxis, 20, mylayerMask);

        if (hit != null && hit.collider != null && hit.collider.tag == "Collectible")
        {
            GameObject.Destroy(hit.collider.gameObject);
        }
    }
}
