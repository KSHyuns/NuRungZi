using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
 
    public Text timeText;
    public GameObject gameOverPop;

    void Start()
    {
        LimitTime = 60f;
    }

    void Update()
    {
        if (LimitTime > 0)
        {
            LimitTime -= Time.deltaTime;
            timeText.text = LimitTime.ToString("#");
        }

        if(LimitTime < 0.5f)
        {
            gameOverPop.SetActive(true);
        }
    }
}
