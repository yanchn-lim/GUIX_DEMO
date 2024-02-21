using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    public WolfHandler wolf;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wolf.playerH.ReduceHealth(8f);
        }
    }
}
