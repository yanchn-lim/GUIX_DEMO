using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    public GameObject popup;

    public override void Interact()
    {
        Debug.Log("I am pedestal");
    }

    public override void PopUp(bool check)
    {
        popup.SetActive(check);
    }
}
