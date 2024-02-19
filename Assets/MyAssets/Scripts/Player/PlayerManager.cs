using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerManager : MonoBehaviour
{
    public PlayerControl controller;
    public PlayerController control;
    public FSM fsm;
    public Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        //controller = GetComponent<PlayerControl>();
        control = GetComponent<PlayerController>();
        fsm = new();

        fsm.Add(new PS_Idle(this));
        fsm.Add(new PS_Move(this));
        fsm.Add(new PS_Attack(this));
    }

    private void Update()
    {
        fsm.Update();   

        if (PlayerInputHandler.MovementPressed)
        {
            fsm.SetCurrentState((int)P_State.MOVE);
        }
    }

    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }
}

public enum P_State
{
    IDLE = 0,
    MOVE,
    ATTACK
}
