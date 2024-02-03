using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForestTrigger : MonoBehaviour
{
    PlayerHandler player;
    public GameObject popup;
    GameHandler gh;

    private void Start()
    {
        gh = GameHandler.instance;
        player = PlayerHandler.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGERED {other.name}");
        popup.SetActive(true);
        MouseHandler.UnlockMouse();
    }


    public void LoadForestScene()
    {
        //gh.SpawnPlayer(gh.forestSpawn);
        //player.transform.position = gh.forestSpawn.position;

        SceneManager.LoadScene("ForestScene");
        player.location = PlayerLocation.FOREST;
        MouseHandler.LockMouse();
    }
}
