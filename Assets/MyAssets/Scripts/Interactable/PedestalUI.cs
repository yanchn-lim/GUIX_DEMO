using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalUI : MonoBehaviour
{
    public GameObject SelectWeaponPanel;
    public GameObject WeaponAugmentPanel;

    public void DisplayWeapon(GameObject s)
    {

    }

    public void OpenWeaponAugmentPanel()
    {
        SelectWeaponPanel.SetActive(false);
        WeaponAugmentPanel.SetActive(true);
    }

    private void OnDisable()
    {
        SelectWeaponPanel.SetActive(true);
        WeaponAugmentPanel.SetActive(false);
    }
}
