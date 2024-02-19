using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfStat : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth;
    public float currHealth;

    #region Stat change
    public void ReduceHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth - amt, 0, maxHealth);
    }

    public void RecoverHealth(float amt)
    {
        currHealth = Mathf.Clamp(currHealth + amt, 0, maxHealth);
    }

    #endregion

    private void Start()
    {
        currHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
        healthBar.value = currHealth;
    }

    private void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        healthBar.value = currHealth;
    }


}
