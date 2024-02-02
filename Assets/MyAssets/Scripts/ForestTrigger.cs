using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForestTrigger : MonoBehaviour
{
    public PlayerHandler player;
    public GameObject popup;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGERED {other.name}");
        popup.SetActive(true);
        MouseHandler.UnlockMouse();
    }


    public void LoadForestScene()
    {
        SceneManager.LoadScene("ForestScene");
        player.location = PlayerLocation.FOREST;
        MouseHandler.LockMouse();
    }
}
