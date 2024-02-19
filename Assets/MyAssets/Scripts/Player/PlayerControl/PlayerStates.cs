using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : FSMState
{
    protected PlayerManager mPlayer = null;

    public PlayerState(PlayerManager player) : base()
    {
        mPlayer = player;
        mFsm = player.fsm;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}

public class PS_Idle : PlayerState
{
    public PS_Idle(PlayerManager player) : base(player)
    {
        mId = (int)P_State.IDLE;
    }

    public override void Update()
    {
        //randomly play idle animations

    }

}

public class PS_Move : PlayerState
{
    public PS_Move(PlayerManager player) : base(player)
    {
        mId = (int)P_State.MOVE;
    }

    public override void Enter()
    {
        Debug.Log("enter move");
    }


    public override void Update()
    {
        mPlayer.control.HandleInput();
    }

    public override void FixedUpdate()
    {
        mPlayer.control.Move();
    }
}

public class PS_Attack : PlayerState
{
    public PS_Attack(PlayerManager player) : base(player)
    {
        mId = (int)P_State.ATTACK;
    }

    public override void Update()
    {


    }

}
