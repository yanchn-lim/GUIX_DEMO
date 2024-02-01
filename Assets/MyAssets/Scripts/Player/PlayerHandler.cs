using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public PlayerLocation location;
    public GameObject StatusPanel;
    public GameObject SkillPanel;

    PlayerAbilities PA;
    PlayerStat PS;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        PA = GetComponent<PlayerAbilities>();
        PS = GetComponent<PlayerStat>()
;    }

    private void Start()
    {
        UpdateHUD_Location();
    }

    private void Update()
    {
        HandleInputs();
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

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PA.Ability1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PA.Ability2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PA.Ability3();
        }
    }
}

public enum PlayerLocation
{
    TOWN,
    FOREST
}
