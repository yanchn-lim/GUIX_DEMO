using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float SprintMultiplier;
    float currSpeed;

    public float gravity;

    public CharacterController cc;
    public Transform cam = default;
    Vector3 forward;
    Vector3 right;
    Vector3 desiredVel;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        //ApplyGravity();
    }

    public void HandleInput()
    {
        if (PlayerInputHandler.DodgePressed)
        {
            Dodge();
        }
    }

    void RotatePlayer()
    {
        if (cam)
        {
            forward = cam.forward;
            forward.y = 0f;
            right = cam.right;
            right.y = 0f;
            Vector3 input = new(PlayerInputHandler.MoveInput.x, 0, PlayerInputHandler.MoveInput.y);
            transform.forward = forward;

            forward.Normalize();
            right.Normalize();
        }
    }

    public void Move()
    {
        currSpeed = MoveSpeed;

        if (cam)
        {
            desiredVel = (transform.forward * PlayerInputHandler.MoveInput.y + transform.right * PlayerInputHandler.MoveInput.x) * currSpeed;
            //desiredVel = (forward * PlayerInputHandler.MoveInput.y + right * PlayerInputHandler.MoveInput.x) * currSpeed;
        }
        else
        {
            desiredVel = new Vector3(PlayerInputHandler.MoveInput.x, 0f, PlayerInputHandler.MoveInput.y) * currSpeed;
        }
        cc.Move(desiredVel * Time.fixedDeltaTime);
    }

    void ApplyGravity()
    {
        cc.SimpleMove(new(0,-gravity,0));
    }

    float dodgeTime = 0.6f;
    float dodgeDist = 10f;

    void Dodge()
    {
        StartCoroutine(DodgeMove());
    }

    IEnumerator DodgeMove()
    {
        float currTime = 0;
        float timing = Time.fixedDeltaTime;

        while (currTime < dodgeTime)
        {
            currTime += timing;
            cc.Move(cc.transform.forward * dodgeDist * timing);
            yield return new WaitForSeconds(timing);
        }
    }
}
