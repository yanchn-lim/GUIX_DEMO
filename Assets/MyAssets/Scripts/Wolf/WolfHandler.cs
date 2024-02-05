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
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(RandomRoam());
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

    void CheckPlayerInRange()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player detected");
        }
    }
}
