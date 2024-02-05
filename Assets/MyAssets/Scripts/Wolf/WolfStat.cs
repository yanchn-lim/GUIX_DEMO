using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfStat : MonoBehaviour
{
    public Image healthBar;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReduceHealth(5f);
        }

        UpdateHUD();
    }

    void UpdateHUD()
    {
        healthBar.fillAmount = currHealth / maxHealth;
    }


}
