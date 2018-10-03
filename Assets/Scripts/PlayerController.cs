using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public FSM playerFSM;

    [HideInInspector]
    public Animator anim;

    private Vector2 currentDirection;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentDirection = Vector2.down;
        playerFSM.subject = this.gameObject;
        playerFSM.Start();
    }

    void Update()
    {
        playerFSM.Update();
    }
}
