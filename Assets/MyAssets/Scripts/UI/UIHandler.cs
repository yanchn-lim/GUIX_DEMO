using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    
    public void CloseUI()
    {
        gameObject.SetActive(false);
        MouseHandler.LockMouse();
    }

    public void ClosePanel(GameObject obj)
    {
        obj.SetActive(false);
        MouseHandler.LockMouse();
    }


    public void StartGame()
    {
        SceneManager.LoadScene("TownScene");
        MouseHandler.LockMouse();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
