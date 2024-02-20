using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    public GameObject pop;
    public Transform canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            //take dmg
            WeaponHit hit = other.GetComponent<WeaponHit>();
            Instantiate(pop,canvas);
            hit.OnHit();
        }
    }


}
