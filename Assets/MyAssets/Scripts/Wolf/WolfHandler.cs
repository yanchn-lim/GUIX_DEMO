using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfHandler : MonoBehaviour
{
    public float walkRadius = 5f;
    public NavMeshAgent agent;

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
    }

    public float delay;

    public void GetRandomState()
    {
        int state = (int)Random.Range(1, fsm.States.Count);
        fsm.SetCurrentState(state);
    }

    IEnumerator RandomRoam()
    {
        while (true)
        {
            Vector3 randPos = Random.insideUnitSphere * walkRadius;
            
            bool yes = NavMesh.SamplePosition(randPos,out NavMeshHit hit, rad,area);

            if (yes)
                agent.destination = hit.position;
            yield return new WaitForSeconds(Random.Range(1f, 8f));
        }
    }

}
