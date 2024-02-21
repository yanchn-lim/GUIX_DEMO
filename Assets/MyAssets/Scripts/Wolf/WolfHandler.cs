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
    public PlayerStat playerH;
    public bool detectedPlayer;

    public WolfStat stat;
    public Animator ani;
    public bool isDead;
    public bool carve;

    public FSM fsm;
    Wolf_Idle idleState;
    Wolf_Roam roamState;
    Wolf_Attack attackState;
    Wolf_Dead deadState;
    public AudioSource audioSource;
    public AudioClip[] attackSFX;
    public BoxCollider attackHitbox;
    public MaterialItem[] itemDrops;
    

    private void Start()
    {
        stat = GetComponent<WolfStat>();
        audioSource = GetComponent<AudioSource>();
        fsm = new();
        idleState = new(this);
        roamState = new(this);
        attackState = new(this);
        deadState = new(this);

        fsm.Add(idleState);
        fsm.Add(roamState);

        agent = GetComponent<NavMeshAgent>();
        fsm.SetCurrentState(idleState);
    }

    float prevValue;

    private void Update()
    {
        if(agent.enabled)
            BlendAnimation();

        if (Input.GetKeyDown(KeyCode.X))
        {

        }

        if(stat.currHealth <= 0 && !isDead)
        {
            isDead = true;
            TriggerDeath();
        }

        fsm.Update();
    }

    void TriggerDeath()
    {
        fsm.Add(deadState);
        fsm.SetCurrentState(deadState);
    }

    public MaterialItem GetRandomItem()
    {
        int index = Random.Range(0, itemDrops.Length);
        return itemDrops[index];
    }

    public void BlendAnimation()
    {
        float currValue = agent.velocity.normalized.magnitude;
        float hV = currValue > prevValue ? currValue : prevValue;
        float lV = currValue > prevValue ? prevValue : currValue;
        float blend = Mathf.Lerp(lV, hV, 0.02f);
        ani.SetFloat("Blend", blend);
        prevValue = agent.velocity.normalized.magnitude;
    }

    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }

    public float delay;

    public void GetRandomState()
    {
        int state = (int)Random.Range(1, fsm.States.Count);
        
        fsm.SetCurrentState(state);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !fsm.States.ContainsValue(attackState))
        {
            playerT = other.transform;
            playerH = other.GetComponentInParent<PlayerStat>();
            detectedPlayer = true;
            fsm.Add(attackState);
        }
    }
}
