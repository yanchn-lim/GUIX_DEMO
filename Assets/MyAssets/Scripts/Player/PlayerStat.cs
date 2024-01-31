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


}
