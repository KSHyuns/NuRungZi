using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    //동물 이미지 이름
    public string animalName;
    //동물 이미지
    public Sprite animal;
    //무기아이템 프리팹
    public GameObject Prefebs;
    //공격력
    public float attackPower;
    //가격
    public int price;
    //설명
    public string explain;
}
