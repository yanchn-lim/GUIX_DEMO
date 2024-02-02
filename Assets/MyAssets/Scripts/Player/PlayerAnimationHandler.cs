using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public PlayerHandler ph;

    void EndRoll()
    {
        ph.EndDodge();
    }
}
