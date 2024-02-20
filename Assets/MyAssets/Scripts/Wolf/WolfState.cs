using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfState : FSMState
{
    protected WolfHandler mWolf = null;

    public WolfState(WolfHandler wolf) : base()
    {
        mWolf = wolf;
        mFsm = wolf.fsm;
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

public enum Wolf_State
{
    IDLE = 0,
    ROAM,
    ATTACK
}

public class Wolf_Idle : WolfState
{
    public Wolf_Idle(WolfHandler wolf) : base(wolf)
    {
        mId = (int)Wolf_State.IDLE;
    }

    public override void Enter()
    {
        Debug.Log("WOLF enter idle");

        mWolf.Invoke("GetRandomState", mWolf.delay);
    }

}

public class Wolf_Roam : WolfState
{
    public Wolf_Roam(WolfHandler wolf) : base(wolf)
    {
        mId = (int)Wolf_State.ROAM;
    }

    public override void Enter()
    {
        Debug.Log("WOLF enter roam");

        Vector3 randPos = Random.insideUnitSphere * mWolf.walkRadius;

        bool yes = NavMesh.SamplePosition(randPos, out NavMeshHit hit, mWolf.rad, mWolf.area);

        if (yes)
            mWolf.agent.SetDestination(hit.position);
    }

    public override void Update()
    {
        if(mWolf.agent.velocity.magnitude <= 0.05f)
        {
            mFsm.SetCurrentState((int)Wolf_State.IDLE);
        }
    }
}

public class Wolf_Attack : WolfState
{
    public Wolf_Attack(WolfHandler wolf) : base(wolf)
    {
        mId = (int)Wolf_State.ATTACK;
    }


    Rigidbody rb;
    NavMeshAgent agent;
    public override void Enter()
    {
        Debug.Log("WOLF enter attack");
        rb = mWolf.rb;
        agent = mWolf.agent;
        mWolf.StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        agent.isStopped = true;
        agent.enabled = false;
        rb.AddForce(mWolf.transform.up * 8f, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        Vector3 dirToPlayer = mWolf.playerT.position - mWolf.transform.position;
        dirToPlayer.y = 0;
        dirToPlayer.Normalize();
        rb.AddForce(dirToPlayer * 20f, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        agent.enabled = true;
        agent.isStopped = false;
        mFsm.SetCurrentState((int)Wolf_State.IDLE);
    }
}