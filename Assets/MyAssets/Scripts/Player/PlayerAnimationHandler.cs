using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerAnimationHandler : MonoBehaviour
{
    PlayerHandler ph;
    public GameObject gsHand;
    public GameObject gsBack;
    RigBuilder rb;

    private void Start()
    {
        ph = PlayerHandler.instance;
        rb = GetComponent<RigBuilder>();    
    }

    void EndRoll()
    {
        ph.EndDodge();
    }

    void EndSheath()
    {
        Debug.Log("end sheath");
        gsBack.SetActive(true);
        gsHand.SetActive(false);
        rb.enabled = false;
    }

    void EndUnsheath()
    {
        Debug.Log("end unsheath");
        gsHand.SetActive(true);
        gsBack.SetActive(false);
        rb.enabled = true;
    }

    void StartAttackIdleTimer()
    {
        atkTimer = 0;
        StartCoroutine(AtkTimer());
    }

    float atkTimer = 0;
    float atkDelay = 1f;
    IEnumerator AtkTimer()
    {
        while(atkTimer > atkDelay)
        {
            atkTimer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void EndAttackIdle()
    {
        ph.atkSeq = 0;
    }

    void StartAttack()
    {
        ph.weaponHitBox.enabled = true;
        Physics.CheckBox(ph.weaponHitBox.bounds.center, ph.weaponHitBox.bounds.extents, Quaternion.identity, ph.attackLayer);
    }

    void EndAttack()
    {
        ph.weaponHitBox.enabled = false;
    }
}
