using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TextLogManager : MonoBehaviour
{
    public static TextLogManager Instance;

    public Text LogText;
    public Canvas parent;
    public List<Text> logList = new List<Text>();

    public Transform startPos;
    public Transform endPos;

    [SerializeField] private bool logOn = false;
   [SerializeField] float timer = 0;

    [SerializeField] Text obj;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        { 
            Destroy(gameObject );
        }

        for (int i = 0; i < 5; i++) 
        {
            var t = GameObject.Instantiate(LogText ,parent.transform);
            t.gameObject.SetActive(false);
            logList.Add(t);
        }
    }

    private Text GetText()
    {
        foreach (var item in logList)
        {
            if (item.gameObject.activeSelf == false)
            {
                return item;
            }
        }
        return null;
    }

    public void ActiveLog(string text)
    {
        if (logOn == false)
        { 
            logOn = true;
            obj = GetText();
            obj.text = text;
            obj.transform.position = startPos.position;
            obj.gameObject.SetActive(true);
        }
       
       // StartCoroutine(LogCoroutine(txt.gameObject , endPos.position ));
    }

    private void Update()
    {
        if (obj)
        {
            timer += Time.deltaTime;
           
            obj.transform. position = Vector3.Lerp(obj.transform.position, new Vector3(endPos.position .x, endPos.position.y, endPos.position.z), Time.deltaTime);

            if (timer >= 1)
            { 
                logOn = false;
                obj.gameObject.SetActive(false);
                timer = 0;
            }

        }
    }


    IEnumerator LogCoroutine(GameObject obj , Vector3 endpos )
    {
        float timer = 0;
        while (timer <= 1)
        { 
            timer += Time.deltaTime ;
         
            obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(transform.position.x,endpos.y, endpos.z), timer  );
            yield return null;
        }

        obj.transform.position = new Vector3(transform.position.x, endpos.y, endpos.z);
        yield return new WaitForSeconds(2);
        timer = 0f;
        while (timer <= 1)
        {
            timer += Time.deltaTime ;

            obj.transform.position = Vector3.Lerp(obj.transform.position, endpos, timer * 0.02f);
            yield return null;
        }

        obj.gameObject.SetActive(false);
        logOn = false;
    }


    IEnumerator LogCoroutine2(GameObject obj, Vector3 endpos, float timer)
    {
       
        while (obj.transform.position.x >= 1f)
        {
            //timer += Time.deltaTime ;

            obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(transform.position.x , endpos.y , endpos.z), timer += Time.deltaTime * 0.01f);
            print(timer);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        obj.gameObject.SetActive(false);

    }



}
