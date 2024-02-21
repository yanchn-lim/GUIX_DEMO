using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCarve : MonoBehaviour
{
    public PlayerHandler ph;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            WolfHandler wolf = other.GetComponentInParent<WolfHandler>();

            if (wolf != null && wolf.isDead)
            {
                ph.PopUpCanvas.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    MaterialItem item = wolf.GetRandomItem();
                    ph.ReceiveItem(item);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ph.PopUpCanvas.SetActive(false);
        }
    }
}
