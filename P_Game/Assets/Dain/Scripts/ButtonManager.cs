using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Slider MusicSlider;
    public GameObject OptionBG;
    public GameObject MenuBG;
    public GameObject EquipBG;
    public GameObject ShopBG;
    AudioSource BGM;

    private void Start()
    {
        OptionBG.SetActive(false);
        MenuBG.SetActive(false);
        EquipBG.SetActive(false);
        ShopBG.SetActive(false);
        BGM = GetComponent<AudioSource>();
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void Stage1Btn()
    {
        SceneManager.LoadScene(2);
    }
    public void Stage2Btn()
    {
        SceneManager.LoadScene(3);
    }
    public void Stage3Btn()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void OptionBtn()
    {
        OptionBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void ShopBtn()
    {
        ShopBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void EquipBtn()
    {
        EquipBG.SetActive(true);
        MenuBG.SetActive(false);
    }
    public void MenuBtn()
    {
        MenuBG.SetActive(true);
    }

    public void CloseBtn()
    {
        OptionBG.SetActive(false);
        MenuBG.SetActive(false);
        EquipBG.SetActive(false);
        ShopBG.SetActive(false);
    }

    public void MusicSlid()
    {
       if(MusicSlider.value >= 1)
        {
            BGM.volume = MusicSlider.value;
        }
    }    

}
