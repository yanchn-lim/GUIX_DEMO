using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    public GameObject popup;
    public GameObject augmentUI;

    public override void Interact()
    {
        Debug.Log("I am pedestal");
        augmentUI.SetActive(true);
    }

    public override void PopUp(bool check)
    {
        popup.SetActive(check);
    }
}
