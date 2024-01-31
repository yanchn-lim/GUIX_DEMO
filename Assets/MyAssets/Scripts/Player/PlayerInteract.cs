using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float checkDist;
    public Transform player;
    public LayerMask mask;
    Ray ray;
    // Update is called once per frame
    void Update()
    {
        ray = new(player.position, Camera.main.transform.forward);
        Debug.DrawRay(player.position, Camera.main.transform.forward,Color.red);
        if (Physics.Raycast(ray,out RaycastHit hit, checkDist, mask))
        {
            hit.collider.gameObject.GetComponent<Interactable>().Interact();
        }
           
    }

}
