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
        bot.animator = GetComponent<Animator>();
        bot.rigidboby2d = GetComponent<Rigidbody2D>();
        bot.transform = GetComponent<Transform>();
        bot.target = target;
        bot.customInput = botInput;
        bot.customInput.currentAxis = Vector2.up;
        bot.customInput.savedAxis = Vector2.up;

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
