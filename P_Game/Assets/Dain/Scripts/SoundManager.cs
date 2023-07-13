using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource BGMSound;
    public AudioClip btnSound;
    public AudioClip openSound;
    public AudioClip attackSound;
    public AudioClip moneySound;
    public AudioClip treasureSound;
    public AudioClip buySound;
    public AudioClip bgSound;
    // Start is called before the first frame update
    void Start()
    {
      

        BGMSound = GetComponent<AudioSource>();
           
    }
    

    public void BtnSound()
    {
        BGMSound.clip = btnSound;
        BGMSound.Play();
    }

    public void OpenSound()
    {
        BGMSound.clip = openSound;
        BGMSound.Play();
    }

    public void AttackSound()
    {
        BGMSound.clip = attackSound;
        BGMSound.Play();
    }
    public void MoneySound()
    {
        BGMSound.clip = moneySound;
        BGMSound.Play();
    }
    public void TreasureSound()
    {
        BGMSound.clip = treasureSound;
        BGMSound.Play();
    }
    public void BuySound()
    {
        BGMSound.clip = buySound;
        BGMSound.Play();
    }
    public void BGSound()
    {
        BGMSound.clip = bgSound;
        BGMSound.Play();
    }
}
