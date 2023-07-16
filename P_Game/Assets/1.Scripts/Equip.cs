using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    //생성할 인벤슬롯의 프리팹
    public InvenSlot invenSlotPrefabs;
    //생성할 인벤슬롯의 부모
    public Transform invenSlotParent;


    [Header("장착 UI 컴포넌트")]
    public GameObject equipInfo_Panel;
    //표시할 이미지
    public Image equipInfo_Sprite;
    //표시할 텍스트
    public Text equipInfo_Name;
  
    //장착버튼
    public Button equipSaveBtn;

    //장착 하려는 아이템
    public Item equipItem;

    //장착 하려는 설명 텍스트
    public Text explain;

    //생성할 인벤슬롯의 리스트
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




        equipSaveBtn.onClick.AddListener(SaveBtn);
    }

    public void SaveBtn()
    {
        SlotManager.Instance.saveItem = equipItem;

    }







}
