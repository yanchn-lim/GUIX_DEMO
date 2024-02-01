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

    #region Stat change
    void ReduceHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth-amt,0,maxHealth);
    }

    void RecoverHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth + amt, 0, maxHealth);
    }

    void ReduceStam(float amt)
    {
        currStam = Mathf.Clamp(currStam - amt, 0, maxStam);
    }

    void RecoverStam(float amt)
    {
        currStam = Mathf.Clamp(currStam + amt, 0, maxStam);
    }
    #endregion

    private void Start()
    {
        currHealth = maxHealth;
        currStam = maxStam;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReduceHealth(5f);
            ReduceStam(4f);
        }

        UpdateHUD();
    }

    void UpdateHUD()
    {
        healthBar.fillAmount = currHealth / maxHealth;
        staminaBar.fillAmount = currStam / maxStam;
    }

}
