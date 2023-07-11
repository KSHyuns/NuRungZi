using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDataBase" , menuName = "Scriptable/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [Header("ITEM == PET")]
    public List<Item> items = new List<Item>();

}
