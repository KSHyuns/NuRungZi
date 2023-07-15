using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public Item myItem;
    public Image myImage;

    private Button myBtn;

    //�������� �κ��� �� �����ɶ� 
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
        SlotManager.Instance.equip.explain.text =    $"{myItem.explain}  \n���ݷ� : {myItem.attackPower}"  ;
    }




}
