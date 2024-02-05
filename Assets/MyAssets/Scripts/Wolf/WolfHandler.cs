using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfHandler : MonoBehaviour
{
    float walkRadius = 5f;
    NavMeshAgent agent;

    public LayerMask area;
    public float rad;

    public SphereCollider sC;

    public Transform playerT;
    public PlayerHandler playerH;
    public bool detectedPlayer;
    public Animator ani;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(RandomRoam());
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

    Coroutine att = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerT = other.transform;
            playerH = other.GetComponentInParent<PlayerHandler>();
            detectedPlayer = true;
            if(att == null)
                att = StartCoroutine(Attack());
        }
    }


    bool desireAttack = false;
    bool attackCD = false;
    public float rand;
    IEnumerator Attack()
    {
        while (true)
        {
            CheckAttack();
            if (desireAttack)
            {
                Debug.Log("ATTACK!");
                Vector3 dir = playerT.position - transform.position;
                float s = 1.5f;
                float t = 0f;
                while (t < s)
                {
                    agent.Move(dir * Time.deltaTime * 2f);
                    t += Time.deltaTime;
                    yield return null;
                }
                desireAttack = false;
                StartCoroutine(AttackCD());
            }

            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }

    void CheckAttack()
    {
        rand = Random.Range(0, 20f);
        if(rand < 5f && !attackCD)
        {
            desireAttack = true;
        }
        else
        {
            desireAttack = false;
        }
    }

    IEnumerator AttackCD()
    {
        attackCD = true;
        float time = 0f;
        while (time > 5f)
        {
            Debug.Log(time);
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        attackCD = false;
    }

    void PerformAttack()
    {

    }

}
