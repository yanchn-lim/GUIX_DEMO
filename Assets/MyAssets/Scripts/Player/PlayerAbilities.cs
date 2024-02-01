using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;

    public Image timer1;
    public Image timer2;
    public Image timer3;

    public float acd1;
    public float acd2;
    public float acd3;

    float at1;
    float at2;
    float at3;
    bool ar1 = true;
    bool ar2 = true;
    bool ar3 = true;

    // Start is called before the first frame update
    void Start()
    {
        at1 = 0;
        at2 = 0;
        at3 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        timer1.fillAmount = at1 / acd1;
        timer2.fillAmount = at2 / acd2;
        timer3.fillAmount = at3 / acd3;
    }

    public void Ability1()
    {
        if (ar1)
        {
            Debug.Log("USE ABILITY 1");
            at1 = acd1;
            StartCoroutine(ATimer1());
        }
        else
        {
            Debug.Log("ABILITY 1 ON CD");
        }
    }

    public void Ability2()
    {
        if (ar2)
        {
            Debug.Log("USE ABILITY 2");
            at2 = acd2;
            StartCoroutine(ATimer2());
        }
        else
        {
            Debug.Log("ABILITY 2 ON CD");
        }
    }
    public void Ability3()
    {
        if (ar3)
        {
            Debug.Log("USE ABILITY 3");
            at3 = acd3;
            StartCoroutine(ATimer3());
        }
        else
        {
            Debug.Log("ABILITY 3 ON CD");
        }
    }

    IEnumerator ATimer1()
    {
        while (at1 > 0)
        {
            at1 -= 0.1f;
            ar1 = false;
            yield return new WaitForSeconds(0.1f);
        }

        ar1 = true;
    }

    IEnumerator ATimer2()
    {
        while (at2 > 0 )
        {
            at2 -= 0.1f;
            ar2 = false;
            yield return new WaitForSeconds(0.1f);
        }

        ar2 = true;
    }
    IEnumerator ATimer3()
    {
        while (at3 > 0)
        {
            at3 -= 0.1f;
            ar3 = false;
            yield return new WaitForSeconds(0.1f);
        }

        ar3 = true;
    }
}
