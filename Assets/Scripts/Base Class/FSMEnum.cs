public enum StateID
{
    Null,
    Idle,
    Walk,
    Run,
    Interact,
    Ride,
    IdleRide,
    Equip,
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
    ToIdleRide,
    ToRed,
    ToYellow,
    ToGreen
}