using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    //�κ��丮�� ���� �ڽ��� ������
    public Item myItem;
    //�κ��������� �̹���
    public Image myImage;
    //�κ������� �ڱ� �ڽ��� ��ư
    private Button myBtn;

    //�������� �κ��� �� �����ɶ� 
    private void Start()
    {
        myBtn = GetComponent<Button>();
   //     myBtn.onClick.RemoveAllListeners();
        //Ŭ���̺�Ʈ 
        myBtn.onClick.AddListener(OnEquip);
    }

    public void OnEquip()
    {
        //�����غ� 
        SlotManager.Instance. equip.equipItem = myItem;
        //����ĭ�� �̹��� ǥ��
        SlotManager.Instance.equip.equipInfo_Sprite.sprite = myItem.animal;
        
        //����ĭ�� �ؽ�Ʈ ǥ��
        SlotManager.Instance.equip.explain.text =    $"{myItem.explain}  \n���ݷ� : {myItem.attackPower}"  ;
    }




}
