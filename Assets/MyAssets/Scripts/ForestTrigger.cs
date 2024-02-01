using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForestTrigger : MonoBehaviour
{
    public PlayerHandler player;
    BoxCollider bc;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGERED {other.name}");
        SceneManager.LoadScene("ForestScene");
        player.location = PlayerLocation.FOREST;
    }

}
