using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUp : MonoBehaviour
{
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(Animate());
    }

    public float animateTime;

    IEnumerator Animate()
    {
        float timer = 0;
        float t = 0.01f;
        while (timer < animateTime)
        {
            Vector3 add = new(0,0.01f, 0);
            transform.position += add;
            float a = text.alpha;
            a -= 1 / (animateTime / t);
            text.alpha = a;

            timer += t;
            yield return new WaitForSeconds(t);
        }

        Destroy(gameObject);
    }
}
