using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoroutine : MonoBehaviour
{
    public Text CoroutineText;

    IEnumerator Start()
    {

        CoroutineText.color = new Color(CoroutineText.color.r, CoroutineText.color.g, CoroutineText.color.b, 0);
        while (CoroutineText.color.a < 1.0f)
        {
            CoroutineText.color = new Color(CoroutineText.color.r, CoroutineText.color.g, CoroutineText.color.b, CoroutineText.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha());
        
    }


    IEnumerator FadeTextToZeroAlpha()
    {
        CoroutineText.color = new Color(CoroutineText.color.r, CoroutineText.color.g, CoroutineText.color.b, 1f);
        while (CoroutineText.color.a > 0)
        {
            CoroutineText.color = new Color(CoroutineText.color.r, CoroutineText.color.g, CoroutineText.color.b, CoroutineText.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(Start());
    }



}
