using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public Item myItem;
    public Image myImage;

    private Button myBtn;

    //아이템이 인벤에 들어가 생성될때 
    private void Start()
    {
        myBtn = GetComponent<Button>();
   //     myBtn.onClick.RemoveAllListeners();
        myBtn.onClick.AddListener(OnEquip);
    }

    public void OnEquip()
    {
        SlotManager.Instance. equip.equipItem = myItem;
        SlotManager.Instance.equip.equipInfo_Sprite.sprite = myItem.animal;
        SlotManager.Instance.equip.explain.text =    $"{myItem.explain}  \n공격력 : {myItem.attackPower}"  ;
    }




}
