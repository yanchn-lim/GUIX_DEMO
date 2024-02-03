using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    PlayerHandler ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = PlayerHandler.instance;
        ph.character.transform.position = transform.position;
    }
}
