using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalUI : MonoBehaviour
{
    public GameObject SelectWeaponPanel;
    public GameObject WeaponAugmentPanel;

    public Camera cam;

    public void DisplayWeapon(GameObject s)
    {

    }


    public void OpenWeaponAugmentPanel()
    {
        SelectWeaponPanel.SetActive(false);
        WeaponAugmentPanel.SetActive(true);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        SelectWeaponPanel.SetActive(true);
        WeaponAugmentPanel.SetActive(false);
    }
}
