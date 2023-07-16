using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //���õ� �ڽ��� ��ư
    private Button clickBtn;
    //�ڱ��ڽ��� ������
    public Item slotitem;
    //������ ������ ���° �ڽ����� 
    [SerializeField] private int slotindex;

    //������ ó�� ������ Item ����
    private void Start()
    {

        //�ڽ��� ��ȣ
        slotindex = transform.GetSiblingIndex();
        //�����ͺ��̽����� ������
        slotitem =   SlotManager.Instance.itemDataBase.items[slotindex];

        //List�� ������ ����
        SlotManager.Instance.slots.Add(slotitem);

        //�ڽ��� ��ư ������Ʈ�� ������
        clickBtn = GetComponent<Button>();
      
        //�ڽ��� ��Ŭ�� �̺�Ʈ ���� - 
        clickBtn.onClick.AddListener(SetItemInfo);

        clickBtn.transform.GetChild(0).GetComponent<Image>().sprite = slotitem.animal;
        clickBtn.transform.GetChild(1).GetComponent<Text>().text = slotitem.price + "$";
        ////��ҹ�ư ��Ŭ���̺�Ʈ ����
        SlotManager.Instance.shop.exitBtn.onClick.AddListener(ExitBtn);
    }

    // �ڽ��� �������� �����ϰ� �Ǹ� 
    private void SetItemInfo()
    {
        //���õ� Item ���� ����
        SlotManager.Instance.shop.selctItem = slotitem;
        SlotManager.Instance.shop.BuyBtn.onClick.RemoveAllListeners();
        ////���Թ�ư ��Ŭ���̺�Ʈ ����
        SlotManager.Instance.shop.BuyBtn.onClick.AddListener(BuyBtn);

    }
    public void BuyBtn()
    {
        //������ ������ ���� �ڱ� �ڽ��� �κ��丮�� �߰����ִٸ� return
        if (SlotManager.Instance.invenSlots.Contains(slotitem))
        {
            return;
        }

        //���� ������ �ִ� �����ڱ��� �����Ϸ��� �����ۺ��� ũ�ٸ� (�˳�)
        if (MoneyManager.money >= slotitem.price)
        {
            //�����ϱ� 
            MoneyManager.money -= slotitem.price;
            
            //�κ��丮�� ���� ����
            InvenSlot invenSlot = Instantiate(SlotManager.Instance.equip.invenSlotPrefabs, 
            SlotManager.Instance.equip.invenSlotParent.transform) as InvenSlot;
    
            //�κ��丮�� ������ ������ ����
            invenSlot.myItem = slotitem;
            //�κ��丮�� ������ ���������̹��� ����
            invenSlot.myImage.sprite = slotitem.animal;
            //�κ��丮 ���� ����Ʈ�� ����
            SlotManager.Instance.invenSlots.Add(slotitem);
        
        }


    }

    public void EquipBtn()
    {
        //������ư Ŭ�� ��  - �̱������� ���� SlotManager. saveItem �� ����
        SlotManager.Instance.saveItem = SlotManager.Instance.shop.selctItem;
        SlotManager.Instance.shop.gameObject.SetActive(false);


    }
    public void ExitBtn()
    {
        //��ҹ�ư Ŭ���� ���� NULL
        SlotManager.Instance.saveItem = null;
        SlotManager.Instance.shop.selctItem = null;
        SlotManager.Instance.shop.gameObject.SetActive(false);
    }


}
