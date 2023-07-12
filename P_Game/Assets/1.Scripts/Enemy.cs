using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHp = 20;
    public Slider hpSlider;
    
    //public Animator Death;



    

    private void Start()
    {
        
    
    }

    public void OnEnable()
    {
        maxHp = 20;
    }

    private void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(5.15f, -1), 15f * Time.deltaTime);
        hpSlider.value = maxHp / 20;

        if (maxHp <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            MoneyManager.money += 100;
        }
    }

    IEnumerator Death()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}