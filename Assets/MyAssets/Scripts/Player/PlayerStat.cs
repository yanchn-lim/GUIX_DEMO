using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;

    public float maxHealth;
    public float currHealth;

    public float maxStam;
    public float currStam;

    bool isStaminaReady;

    #region Stat change
    public void ReduceHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth-amt,0,maxHealth);
    }

    public void RecoverHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth + amt, 0, maxHealth);
    }

    public void ReduceStam(float amt)
    {
        currStam = Mathf.Clamp(currStam - amt, 0, maxStam);
        isStaminaReady = false;
    }

    public void RecoverStam(float amt)
    {
        currStam = Mathf.Clamp(currStam + amt, 0, maxStam);
    }

    public bool EnoughStamina(float amt)
    {
        return currStam > amt;
    }
    #endregion

    private void Start()
    {
        currHealth = maxHealth;
        currStam = maxStam;

        StartCoroutine(RegenerateStamina());
    }

    private void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        healthBar.fillAmount = currHealth / maxHealth;
        staminaBar.fillAmount = currStam / maxStam;
    }

    IEnumerator RegenerateStamina()
    {
        float delayTimer = 0f;
        float timer = 1f;
        while (true)
        {
            if (!isStaminaReady)
            {
                while (delayTimer < timer)
                {
                    delayTimer += 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
                delayTimer = 0f;
                isStaminaReady = true;
            }
               
            while(currStam < maxStam && isStaminaReady)
            {
                RecoverStam(Time.deltaTime * 8);
                yield return null;
            }

            yield return null;
        }
    }
}
