using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    
    public void CloseUI()
    {
        gameObject.SetActive(false);
        MouseHandler.LockMouse();
    }
}
