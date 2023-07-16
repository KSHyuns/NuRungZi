using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    //싱글톤 인스턴스
   public static SlotManager Instance;

    [Header("Scriptable로 생성한 DataBase")]
    public ItemDataBase itemDataBase;

    [Header("장착 하면 요놈한테 들어감")]
    public Item saveItem;

    [Header("상점슬롯리스트")]
    public List<Item> slots = new List<Item>();

    [Header("인벤슬롯리스트")]
    public List<Item> invenSlots = new List<Item>();


    public Shop shop; // 상점...
    public Equip equip;  //장착 및 인벤


    private void Awake()
    {
        Instance = this;
    }

}
