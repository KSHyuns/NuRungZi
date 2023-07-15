using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //������ ��ư ������Ʈ�� �������ֽ�.
    private Button clickBtn;
    //�ڱ��ڽ��� ������
    public Item slotitem;
    //���° �ڽ����� 
    [SerializeField] private int slotindex;

    

    //������ ó�� ������ Item ����
    private void Start()
    {

        //�ڽ��� �ڽĹ�ȣ
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
        //shop.selectItem_Sprite.sprite = shop.selctItem.animal;
        //shop.selectItemInfo_Name.text = shop.selctItem.animalName;
        //shop.selectItemInfo_Panel.gameObject.SetActive(true);


        SlotManager.Instance.shop.BuyBtn.onClick.RemoveAllListeners();
      

        ////���Թ�ư ��Ŭ���̺�Ʈ ����
        SlotManager.Instance.shop.BuyBtn.onClick.AddListener(BuyBtn);

    }
    public void BuyBtn()
    {

        if (SlotManager.Instance.invenSlots.Contains(slotitem))
        {
            return;
        }

        if (MoneyManager.money >= slotitem.price)
        {
            MoneyManager.money -= slotitem.price;
        
            InvenSlot invenSlot = Instantiate(SlotManager.Instance.equip.invenSlotPrefabs, 
            SlotManager.Instance.equip.invenSlotParent.transform) as InvenSlot;
  
            invenSlot.myItem = slotitem;
            invenSlot.myImage.sprite = slotitem.animal;
            SlotManager.Instance.invenSlots.Add(slotitem);
        
        }


    }

    public void EquipBtn()
    {
        //������ư Ŭ�� ��  - �̱������� ���� SlotManager. saveItem �� ����
        SlotManager.Instance.saveItem = SlotManager.Instance.shop.selctItem;
        SlotManager.Instance.shop.gameObject.SetActive(false);

        //����� saveItem�� �ִ� ���� �̸��� Text�� ǥ��...
      //  shop.equipInfo_Name.text = SlotManager.Instance.saveItem.animalName;
     //   shop.equipInfo_Sprite.sprite = SlotManager.Instance.saveItem.animal;

    }
    public void ExitBtn()
    {
        //��ҹ�ư Ŭ���� ���� NULL
        SlotManager.Instance.saveItem = null;
        SlotManager.Instance.shop.selctItem = null;
        SlotManager.Instance.shop.gameObject.SetActive(false);
    }


}
