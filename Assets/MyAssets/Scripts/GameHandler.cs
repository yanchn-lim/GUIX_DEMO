using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public Transform player;
    public Transform forestSpawn;
    public Transform townSpawn;
    CharacterController c;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SpawnPlayer(Transform spawn)
    {
        Debug.Log("spawning player");
        player.position = spawn.position;
        Debug.Log($"{player.position}, {spawn.position}");
    }
}
