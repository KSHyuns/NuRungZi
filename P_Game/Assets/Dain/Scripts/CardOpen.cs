using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOpen : MonoBehaviour
{
    public GameObject[] Rewards;
    public GameObject Card;
    public void cardOpen()
    {
        Card.SetActive(true);
        Reward();
        ButtonManager buttonManager = GameObject.FindObjectOfType<ButtonManager>();
        buttonManager.RewardsCloseBtn.SetActive(true);
    }

    public void Reward()
    {
        int x = Random.Range(0, Rewards.Length);
        Rewards[x].SetActive(true);
    }

   

    
}
