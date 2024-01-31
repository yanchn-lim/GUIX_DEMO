using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseHandler
{
    public static void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
