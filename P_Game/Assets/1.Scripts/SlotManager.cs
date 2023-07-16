using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    //�̱��� �ν��Ͻ�
   public static SlotManager Instance;

    [Header("Scriptable�� ������ DataBase")]
    public ItemDataBase itemDataBase;

    [Header("���� �ϸ� ������� ��")]
    public Item saveItem;

    [Header("�������Ը���Ʈ")]
    public List<Item> slots = new List<Item>();

    [Header("�κ����Ը���Ʈ")]
    public List<Item> invenSlots = new List<Item>();


    public Shop shop; // ����...
    public Equip equip;  //���� �� �κ�


    private void Awake()
    {
        Instance = this;
    }

}
