using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text timeText;
    void Start()
    {
        LimitTime = 60f;
    }

    void Update()
    {
        LimitTime -= Time.deltaTime;
        timeText.text = LimitTime.ToString("#");

        if(LimitTime < 0.5f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
