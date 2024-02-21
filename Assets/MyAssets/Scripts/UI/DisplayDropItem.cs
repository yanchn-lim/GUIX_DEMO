using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayDropItem : MonoBehaviour
{
    public TMP_Text text;
    public Image img;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    public void DisplayItemInfo(MaterialItem item)
    {
        img.sprite = item.Sprite;
        text.text = $"x{item.Amount} {item.Name} Received";
    }


    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
