using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float checkDist;
    public Transform player;
    public LayerMask mask;
    Ray ray;
    Interactable currInt;
    bool rayHit;

    // Update is called once per frame
    void Update()
    {
        DetectInteractable();

        if(rayHit)
        {
            HandleInput();
        }
    }

    void DetectInteractable()
    {
        ray = new(player.position, Camera.main.transform.forward);
        Debug.DrawRay(player.position, Camera.main.transform.forward,Color.red);
        rayHit = Physics.Raycast(ray, out RaycastHit hit, checkDist, mask);
        if (rayHit)
        {
            currInt = hit.collider.gameObject.GetComponent<Interactable>();
        }
        currInt.PopUp(rayHit);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currInt.Interact();
        }
    }
}
