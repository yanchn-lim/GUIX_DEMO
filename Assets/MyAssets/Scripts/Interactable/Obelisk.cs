using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obelisk : Interactable
{
    public GameObject popup;
    public GameObject returnUI;
    public Transform marker;
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

    private void Start()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        while (true)
        {
            marker.Rotate(new(0, 1, 0));
            yield return new WaitForSeconds(0.01f);

        }
    }
}
