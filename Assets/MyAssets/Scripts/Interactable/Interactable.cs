using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, I_Interact
{
    public abstract void Interact();
}
