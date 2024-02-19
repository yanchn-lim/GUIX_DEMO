using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponHit : MonoBehaviour
{
    public float damage;
    public float hitLagDuration = 0.1f; // Adjust the duration as needed
    private bool isHitLagActive = false;
    BoxCollider hitbox;
    CinemachineImpulseSource impulseSource;

    public void OnHit()
    {
        ApplyHitLag();
        TurnOffHitbox();
        impulseSource.GenerateImpulse();
    }

    void TurnOffHitbox()
    {
        hitbox.enabled = false;
    }

    private void Start()
    {
        hitbox = GetComponent<BoxCollider>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    IEnumerator EndHitLag()
    {
        yield return new WaitForSecondsRealtime(hitLagDuration);
        Time.timeScale = 1.0f; // Resume normal time scale
        isHitLagActive = false;
    }

    void ApplyHitLag()
    {
        isHitLagActive = true;
        Time.timeScale = 0.0f; // Freeze the game during hit lag
        StartCoroutine(EndHitLag());
    }
}
