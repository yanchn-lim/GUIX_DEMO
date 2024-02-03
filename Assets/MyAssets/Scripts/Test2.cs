using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"sword hit {other.name}");
    }
}
