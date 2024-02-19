using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public WolfStat stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            Debug.Log("IM HIT BY PLAYER");

            //take dmg
            WeaponHit hit = other.GetComponent<WeaponHit>();
            stat.ReduceHealth(hit.damage);
            hit.OnHit();
        }
    }
}
