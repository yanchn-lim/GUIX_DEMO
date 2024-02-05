using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerHandler : MonoBehaviour
{
    public PlayerLocation location;
    public GameObject StatusPanel;
    public GameObject SkillPanel;
    public GameObject InventoryPanel;
    public CharacterController character;
    PlayerAbilities PA;
    PlayerStat PS;

    bool IsWeaponSheath = true;
    public bool IsDodging = false;

    public Animator ani;

    float dodgeFrames = 0.6f;
    float dodgeDist = 2f;
    public StarterAssetsInputs input;

    public LayerMask dodgeMask;
    public LayerMask normMask;

    public static PlayerHandler instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance == null)
        {
            instance = this;
        }
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

        if (Input.GetKeyDown(KeyCode.Space) && !IsDodging)
        {
            Dodge();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInvetory();
        }

        if (Input.GetMouseButtonDown(0) && !IsWeaponSheath)
        {
            Attack();
        }
    }

    bool inventoryOpen = false;

    void OpenInvetory()
    {
        if (inventoryOpen)
        {
            MouseHandler.LockMouse();
            InventoryPanel.SetActive(false);
            inventoryOpen = false;
        }
        else
        {
            MouseHandler.UnlockMouse();
            InventoryPanel.SetActive(true);
            inventoryOpen = true;
        }
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
        if (!PS.EnoughStamina(20f))
            return;

        IsDodging = true;
        ani.SetTrigger("Roll");

        if(location != PlayerLocation.TOWN)
            PS.ReduceStam(20f);

        StartCoroutine(DodgeMove());
    }

    IEnumerator DodgeMove()
    {
        float currFrame = 0;
        float timing = 0.016f;

        while (currFrame < dodgeFrames)
        {
            currFrame += timing;
            character.Move(character.transform.forward * dodgeDist * timing);
            yield return new WaitForSeconds(timing);
        }
    }

    public void EndDodge()
    {
        IsDodging = false;
        Debug.Log("dodge ended");
    }


    #region ATTACK

    float atkTimer = 0;
    public int atkSeq = 0;
    public BoxCollider weaponHitBox;
    public LayerMask attackLayer;
    void Attack()
    {
        string atkName = $"Attack_{atkSeq + 1}";
        ani.SetTrigger(atkName);
        atkSeq += 1;
        if(atkSeq > 3)
        {
            atkSeq = 0;
        }
    }


    #endregion

    #endregion
}

public enum PlayerLocation
{
    TOWN,
    FOREST
}
