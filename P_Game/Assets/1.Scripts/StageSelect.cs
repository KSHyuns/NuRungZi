using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{

    private string saveKey = "StageSelect";
    
    private void Start()
    {
        MoneyManager.money = 1000;
        if (PlayerPrefs.HasKey(saveKey))
        {
            StageNumber = PlayerPrefs.GetInt(saveKey);
        }
        else
        { 
            StageNumber = 0;
        }

    }

    public int StageNumber
    {
        get => stageNumber;
        set 
        {
             stageNumber = value;
            if (stageNumber < stageButton.Length)
            { 
                for(int i = 0; i < value+1; i++) 
                {
                    stageButton[i].interactable = true;
                }
            
            }
        }
    }

    private int stageNumber;

    public Button[] stageButton;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StageNumber++;
    }


}
