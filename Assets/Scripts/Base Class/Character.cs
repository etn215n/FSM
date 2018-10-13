using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Animator animator;
    public Rigidbody rigidboby;
    public Rigidbody2D rigidboby2d;
    public CustomInput customInput;
    public Transform transform;
    public GameObject target;

    public virtual void SetIdleAnimation() {}
    public virtual void SetWalkAnimation() {}
    public virtual void SetRunAnimation() {}
    public virtual void SetInteractAnimation() {}
    public virtual void SetEquipAnimation() {}

    public virtual void UpdateWalkAnimation() {}
    public virtual void UpdateRunAnimation() {}

    public virtual bool ConditionToIdle() {return false;}
    public virtual bool ConditionToNotIdle() {return false;}
    public virtual bool ConditionToWalk() {return false;}
    public virtual bool ConditionToNotWalk() {return false;}
    public virtual bool ConditionToRun() {return false;}
    public virtual bool ConditionToNotRun() {return false;}
    public virtual bool ConditionToInteract() {return false;}
    public virtual bool ConditionToEquip() {return false;}

    public virtual void Walk() {}
    public virtual void Idle() {}
    public virtual void Run() {}
    public virtual void Interact() {}
    public virtual void PickUp() {}
}
