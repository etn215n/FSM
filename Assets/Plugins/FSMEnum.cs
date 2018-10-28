namespace StateMachine
{
    public enum StateID
    {
        Null               = 0,
        Idle               = 1,
        Walk               = 2,
        Run                = 3,
        Interact           = 4,
        Equip              = 5,
        Unequip            = 6,
        IdleRide           = 7,
        Ride               = 8
    }

    public enum Transition
    {
        Null,
        ToIdle,
        ToWalk,
        ToRun,
        ToInteract,
        ToEquip,
        ToUnequip,
        ToIdleRide,
        ToRide,
    }
}