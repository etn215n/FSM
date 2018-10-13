public enum StateID
{
    Null,
    Idle,
    Walk,
    Run,
    Interact,
    Equip,
    Unequip,
    Ride,
    IdleRide,
    Red,
    Yellow,
    Green
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
    ToRed,
    ToYellow,
    ToGreen
}