using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public Slot SlotPrefab;
    public GameObject parent;

    [Header("상점 아이템 저장용")]
    public Item selctItem;

    [Header("상점  아이템 정보 팝업창 컴포넌트")]
    public GameObject selectItemInfo_Panel;
    public Image selectItem_Sprite;
    public Text selectItemInfo_Name;
    public Button equipBtn;
    public Button exitBtn;


    [Header("장착 UI 컴포넌트")]
    public GameObject equipInfo_Panel;
    public Image equipInfo_Sprite;
    public Text  equipInfo_Name;
    

    private void Start()
    {
        //데이타베이스에 저장되있는 펫? 아이템? 의 갯수
        int index = SlotManager.Instance.itemDataBase.items.Count;
        for (int i = 0; i < index; i++)
        {
            //갯수만큼 생성 후 
            Slot slot =  Instantiate(SlotPrefab, parent.transform) ;
            //List에 슬롯을 저장
            SlotManager.Instance.slots.Add(slot);
        }

    }
}
