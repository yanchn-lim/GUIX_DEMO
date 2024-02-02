using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerHandler : MonoBehaviour
{
    public PlayerLocation location;
    public GameObject StatusPanel;
    public GameObject SkillPanel;
    public CharacterController character;
    PlayerAbilities PA;
    PlayerStat PS;

    bool IsWeaponSheath = true;
    public bool IsDodging = false;

    public Animator ani;

    float dodgeFrames = 0.6f;
    float dodgeDist = 1.5f;
    public StarterAssetsInputs input;

    public LayerMask dodgeMask;
    public LayerMask normMask;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        PA = GetComponent<PlayerAbilities>();
        PS = GetComponent<PlayerStat>()
;    }

    private void Start()
    {
        MouseHandler.input = input;
        UpdateHUD_Location();
    }

    private void Update()
    {
        HandleInputs();
        UpdateHUD_Location();
        character.excludeLayers = IsDodging? dodgeMask : normMask ;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SheathWeapon();
        }

        if (Input.GetKeyDown(KeyCode.X) && !IsDodging)
        {
            Dodge();
        }

        if (input.sprint && location != PlayerLocation.TOWN)
        {
            PS.ReduceStam(Time.deltaTime * 10f);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInvetory();
        }
    }

    void OpenInvetory()
    {
        MouseHandler.LockMouse();

    }


    #region Player Control
    void SheathWeapon()
    {
        if (IsWeaponSheath)
        {
            IsWeaponSheath = false;
            ani.SetTrigger("Unsheath");
        }
        else
        {
            IsWeaponSheath = true;
            ani.SetTrigger("Sheath");
        }

        ani.SetBool("IsSheathed", IsWeaponSheath);
    }

    void Dodge()
    {
        IsDodging = true;
        ani.SetTrigger("Roll");
        Vector3 dir = new(input.move.x * character.transform.forward.x, 0, input.move.y*character.transform.forward.z);

        dir.Normalize();

        if(location != PlayerLocation.TOWN)
            PS.ReduceStam(20f);

        StartCoroutine(DodgeMove(dir));
    }

    IEnumerator DodgeMove(Vector3 dir)
    {
        float currFrame = 0;
        float timing = 0.016f;
        if (dir == Vector3.zero)
            dir = character.transform.forward;
        while (currFrame < dodgeFrames)
        {
            currFrame += timing;
            character.Move(dir * dodgeDist * timing);
            yield return new WaitForSeconds(timing);
        }
    }

    public void EndDodge()
    {
        IsDodging = false;
        Debug.Log("dodge ended");
    }
    #endregion
}

public enum PlayerLocation
{
    TOWN,
    FOREST
}
