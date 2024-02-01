using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public PlayerLocation location;
    public GameObject StatusPanel;
    public GameObject SkillPanel;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UpdateHUD_Location();
    }

    void UpdateHUD_Location()
    {
        switch (location)
        {
            case PlayerLocation.TOWN:
                //display town HUD
                StatusPanel.SetActive(false);
                SkillPanel.SetActive(false);
                break;
            case PlayerLocation.FOREST:
                //display combat HUD
                StatusPanel.SetActive(true);
                SkillPanel.SetActive(true);
                break;
        }
    }
}

public enum PlayerLocation
{
    TOWN,
    FOREST
}
