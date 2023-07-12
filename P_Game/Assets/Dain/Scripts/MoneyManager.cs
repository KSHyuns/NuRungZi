using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public Text Money;
    public Text StarCoin;       // 과금머니(starCoin) 표시용 Text입니다.

    public static Func<int> action;

    public static int money;
    public static int starCoin; // 과금머니(starCoin) 저장용입니다.

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Money.text = $"{string.Format("{0:n0}",money)}";
        StarCoin.text = $"{string.Format("{0:n0}", starCoin)}";
    }
}
