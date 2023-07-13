using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiticeText : MonoBehaviour
{
    public Text noticeText;

    private void Start()
    {
        noticeText.color = new Color(noticeText.color.r, noticeText.color.g, noticeText.color.b, 0);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        { StartCoroutine(notice()); }
    }

    IEnumerator notice()
    {
        noticeText.text = "돈이 없습니다.";
        
        noticeText.color = new Color(noticeText.color.r, noticeText.color.g, noticeText.color.b, noticeText.color.a + (Time.deltaTime / 2.0f));

        yield return new WaitForSeconds(2f);

        noticeText.color = new Color(noticeText.color.r, noticeText.color.g, noticeText.color.b, noticeText.color.a - (Time.deltaTime / 2.0f));
        
    }


}
