using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfHandler : MonoBehaviour
{
    public float walkRadius = 10f;
    public NavMeshAgent agent;
    public Rigidbody rb;

    public LayerMask area;
    public float rad;

    public Transform playerT;
    public PlayerHandler playerH;
    public bool detectedPlayer;
    public Animator ani;

    public FSM fsm;
    Wolf_Idle idleState;
    Wolf_Roam roamState;
    Wolf_Attack attackState;

    Vector3 dirToPlayer;

    private void Start()
    {
        fsm = new();
        idleState = new(this);
        roamState = new(this);
        attackState = new(this);

        fsm.Add(idleState);
        fsm.Add(roamState);
        fsm.Add(attackState);

        agent = GetComponent<NavMeshAgent>();
        fsm.SetCurrentState(idleState);
        //StartCoroutine(RandomRoam());
    }

    float prevValue;

    private void Update()
    {
        float currValue = agent.velocity.normalized.magnitude;
        float hV = currValue > prevValue ? currValue : prevValue;
        float lV = currValue > prevValue ? prevValue : currValue;
        float blend = Mathf.Lerp(lV,hV,0.02f);
        ani.SetFloat("Blend", blend);
        prevValue = agent.velocity.normalized.magnitude;

        dirToPlayer = playerT.position - transform.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Attack());
        }

        fsm.Update();
    }

    IEnumerator Attack()
    {
        agent.isStopped = true;
        rb.AddForce(transform.up * 10f,ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(dirToPlayer.normalized * 100f, ForceMode.Impulse);
        yield return new WaitForSeconds(5f);
        agent.isStopped = false;
    }

    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }

    public float delay;

    public void GetRandomState()
    {
        int state = (int)Random.Range(1, fsm.States.Count);
        fsm.SetCurrentState(1);
    }
}
