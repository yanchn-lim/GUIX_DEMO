using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obelisk : Interactable
{
    public GameObject popup;
    public GameObject returnUI;
    public override void Interact()
    {
        Debug.Log("I am obelisk");
        returnUI.SetActive(true);
        MouseHandler.UnlockMouse();
    }

    public override void PopUp(bool check)
    {
        popup.SetActive(check);
    }

    public void No()
    {
        Debug.Log("NO");
        MouseHandler.LockMouse();
        returnUI.SetActive(false);
    }
    
    public void Yes()
    {
        Debug.Log("YES");
        MouseHandler.LockMouse();
        SceneManager.LoadScene("TownScene");
    }
}
