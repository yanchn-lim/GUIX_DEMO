using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalUI : MonoBehaviour
{
    public GameObject SelectWeaponPanel;
    public GameObject WeaponAugmentPanel;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public Camera cam;

    public void DisplayWeapon(GameObject s)
    {

    }

    public void DisplayAugmentSlot()
    {
        Vector3 v = point1.transform.position;
        Vector3 vv = slot1.transform.position;
        Vector3[] vA = { v, vv };

        Vector3 v2 = point2.transform.position;
        Vector3 vv2 = slot2.transform.position;
        Vector3[] vA2 = { v2, vv2 };

        Vector3 v3 = point3.transform.position;
        Vector3 vv3 = slot3.transform.position;
        Vector3[] vA3 = { v3, vv3  };


        slot1.GetComponent<LineRenderer>().SetPositions(vA);
        slot2.GetComponent<LineRenderer>().SetPositions(vA2);
        slot3.GetComponent<LineRenderer>().SetPositions(vA3);

    }

    public void OpenWeaponAugmentPanel()
    {
        SelectWeaponPanel.SetActive(false);
        WeaponAugmentPanel.SetActive(true);
    }

    private void OnEnable()
    {
        DisplayAugmentSlot();

    }

    private void OnDisable()
    {
        SelectWeaponPanel.SetActive(true);
        WeaponAugmentPanel.SetActive(false);
    }
}
