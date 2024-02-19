using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public BoxCollider hitbox;
    public BoxCollider attackbox;
    public Transform attackboxT;

    public bool attack;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        Transform t = attackboxT;
        Vector3 startPos = t.position;
        float timer = 0;
        while (true)
        {
            if (!attack)
            {
                yield return null;
                continue;
            }

            t.Rotate(0,0.5f,0);

            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
