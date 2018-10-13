using UnityEngine;

public class PlayerEquipState : FSMState 
{
    public PlayerEquipState() : base()
    {
        this.stateID = StateID.Equip;
        transitionMap.Add(Transition.ToUnequip, StateID.Unequip);
    }
}
