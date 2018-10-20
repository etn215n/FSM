using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour 
{
    private FSM botFSM;
    private BotCharacter bot;
    private Transform transform;
    public GameObject target;
    private CustomInput botInput;

    void Start()
    {
        botInput = new CustomInput();
        bot = new BotCharacter();
        bot.SetAnimator(GetComponent<Animator>());
        bot.Set2DRigidbody(GetComponent<Rigidbody2D>());
        bot.SetTransform(GetComponent<Transform>());
        bot.SetTarget(target);
        bot.SetInput(botInput);

        botFSM = new FSM(bot);
        botFSM.AddState(new PlayerIdleState());
        botFSM.AddState(new PlayerWalkState());
        botFSM.AddState(new PlayerRunState());
        botFSM.Start();
    }

    void Update()
    {
        botFSM.Update();
    }

    void FixedUpdate()
    {
        botFSM.FixedUpdate();
    }
}
