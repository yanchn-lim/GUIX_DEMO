using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerAnimationHandler : MonoBehaviour
{
    public PlayerHandler ph;
    public GameObject gsHand;
    public GameObject gsBack;
    RigBuilder rb;

    private void Start()
    {
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
}
