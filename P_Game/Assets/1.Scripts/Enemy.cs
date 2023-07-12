using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHp = 20;
    public Slider hpSlider;
    int killCount;
    public void OnEnable() { maxHp = 20; } //적의 체력 초기화
    private void Update()
    {
        gameObject.transform.position =
            Vector2.MoveTowards(gameObject.transform.position, new Vector2(5.15f, -1), 15f * Time.deltaTime);
        if (maxHp <= 0)
        {
            FindObjectOfType<EnemySpawner>().killCount++;
            //gameObject.SetActive(false);
            MoneyManager.money += 100;
            Destroy(gameObject);
        }
    }
}