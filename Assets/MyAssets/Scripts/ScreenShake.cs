using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.3f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void ApplyScreenShake()
    {
        if (!IsInvoking("StopShake"))
        {
            InvokeRepeating("DoShake", 0, 0.01f);
            Invoke("StopShake", shakeDuration);
        }
    }

    void DoShake()
    {
        float shakeX = Random.Range(-1f, 1f) * shakeIntensity;
        float shakeY = Random.Range(-1f, 1f) * shakeIntensity;

        transform.localPosition = new Vector3(originalPosition.x + shakeX, originalPosition.y + shakeY, originalPosition.z);
        Debug.Log("shaking");
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        transform.localPosition = originalPosition;
        Debug.Log("shake end");
    }
}
