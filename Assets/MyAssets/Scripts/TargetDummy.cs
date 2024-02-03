using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OW");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} in me");
    }
}
