using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    //인벤토리의 슬롯 자신의 아이템
    public Item myItem;
    //인벤아이템의 이미지
    public Image myImage;
    //인벤아이템 자기 자신의 버튼
    private Button myBtn;

    //아이템이 인벤에 들어가 생성될때 
    private void Start()
    {
        myBtn = GetComponent<Button>();
   //     myBtn.onClick.RemoveAllListeners();
        //클릭이벤트 
        myBtn.onClick.AddListener(OnEquip);
    }

    public void OnEquip()
    {
        //장착준비 
        SlotManager.Instance. equip.equipItem = myItem;
        //장착칸의 이미지 표시
        SlotManager.Instance.equip.equipInfo_Sprite.sprite = myItem.animal;
        
        //장착칸의 텍스트 표시
        SlotManager.Instance.equip.explain.text =    $"{myItem.explain}  \n공격력 : {myItem.attackPower}"  ;
    }




}
