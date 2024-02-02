using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public static class MouseHandler
{
    public static StarterAssetsInputs input;

    public static void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        input.cursorInputForLook = true;
    }

    public static void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        input.cursorInputForLook = false;
    }
}
