using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameHandler instance;
    public Transform player;
    public Transform forestSpawn;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance == null)
        {
            instance = this;
        }
    }

    void SpawnPlayer(Transform spawn)
    {
        player.position = spawn.position;
    }
}
