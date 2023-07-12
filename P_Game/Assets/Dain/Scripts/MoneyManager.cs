using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public Text Money;

    public static Func<int> action;

    public static int money;
    // Start is called before the first frame update
    
    
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Money.text = $"{string.Format("{0:n0}",money)}";
    }
}
