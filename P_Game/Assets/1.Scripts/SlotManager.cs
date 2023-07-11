using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
   public static SlotManager Instance;

    [Header("Scriptable로 생성한 DataBase")]
    public ItemDataBase itemDataBase;

    [Header("장착 하면 요놈한테 들어감")]
    public Item saveItem;
    [Header("상점슬롯리스트")]
    public List<Slot> slots = new List<Slot>();

    private void Awake()
    {
        Instance = this;
    }

}
