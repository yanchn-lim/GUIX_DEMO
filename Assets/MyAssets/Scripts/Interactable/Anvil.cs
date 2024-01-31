using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil :Interactable
{
    public GameObject popup;

    public override void Interact()
    {
        Debug.Log("I am anvil");
    }

    public override void PopUp(bool check)
    {
        popup.SetActive(check);
    }

}
