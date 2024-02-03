using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnvilTreeUI : MonoBehaviour
{
    public TMP_Text itemName;
    public Image itemSprite;
    public TMP_Text itemDMG;
    public TMP_Text itemFX;

    public void DisplayItem(Item item)
    {
        itemName.text = item.n;
        itemDMG.text = $"Damage : {item.dmg}";
        itemFX.text = $"Effect : {item.fx}";
        itemSprite.sprite = item.sprite;
    }
}
