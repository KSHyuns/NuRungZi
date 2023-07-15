using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{

    public InvenSlot invenSlotPrefabs;
    public Transform invenSlotParent;


    [Header("ÀåÂø UI ÄÄÆ÷³ÍÆ®")]
    public GameObject equipInfo_Panel;
    public Image equipInfo_Sprite;
    public Text equipInfo_Name;
  
    public Button equipBtn;

    public Item equipItem;

    
    public Text explain;

    public List<GameObject> invenGameobject = new List<GameObject>();
    private void Start()
    {

        if (SlotManager.Instance.invenSlots.Count >= 0)
        {
            foreach (var item in invenGameobject)
            {
                Destroy(item);
            }
            invenGameobject.Clear();
        }

        for (int i = 0; i < SlotManager.Instance.invenSlots.Count; i++)
        {
        InvenSlot invenSlot = Instantiate(SlotManager.Instance.equip.invenSlotPrefabs,
           SlotManager.Instance.equip.invenSlotParent.transform) as InvenSlot;
            invenGameobject.Add(invenSlot.gameObject);

            invenSlot.myItem = SlotManager.Instance.invenSlots[i];
            invenSlot.myImage.sprite = SlotManager.Instance.invenSlots[i].animal;
            SlotManager.Instance.invenSlots.Add(invenSlot.myItem);

        }




        equipBtn.onClick.AddListener(SaveBtn);
    }

    public void SaveBtn()
    {
        SlotManager.Instance.saveItem = equipItem;

    }







}
