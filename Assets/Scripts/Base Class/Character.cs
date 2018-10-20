using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    protected Animator animator;
    protected Rigidbody2D rigidboby2d;
    protected CustomInput customInput;
    protected Transform transform;
    protected GameObject target;

    public virtual void SetAnimator(Animator animator) { this.animator = animator; }
    public virtual void Set2DRigidbody(Rigidbody2D rigidboby2d) { this.rigidboby2d = rigidboby2d; }
    public virtual void SetInput(CustomInput customInput) { this.customInput = customInput; }
    public virtual void SetTarget(GameObject target) { this.target = target; }
    public virtual void SetTransform(Transform transform) { this.transform = transform; }

    public virtual void SetIdleAnimation() {}
    public virtual void SetWalkAnimation() {}
    public virtual void SetRunAnimation() {}
    public virtual void SetInteractAnimation() {}
    public virtual void SetEquipAnimation() {}
    public virtual void SetUnequipAnimation() {}
    public virtual void SetRideAnimation() {}
    public virtual void SetIdleRideAnimation() {}

    public virtual bool ConditionToIdle()     { return false; }
    public virtual bool ConditionToWalk()     { return false; }
    public virtual bool ConditionToRun()      { return false; }
    public virtual bool ConditionToInteract() { return false; }
    public virtual bool ConditionToEquip()    { return false; }
    public virtual bool ConditionToUnequip()  { return false; }
    public virtual bool ConditionToRide()     { return false; }
    public virtual bool ConditionToIdleRide() { return false; }

    public virtual void Walk() {}
    public virtual void Idle() {}
    public virtual void Run() {}
    public virtual void Ride() {}
    public virtual void Interact() {}
    public virtual void PickUp() {}
}
