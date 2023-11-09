using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int hp;
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;

        }
    }



}
