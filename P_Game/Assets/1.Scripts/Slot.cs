using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //선택될 자신의 버튼
    private Button clickBtn;
    //자기자신의 아이템
    public Item slotitem;
    //생성된 슬롯이 몇번째 자식인지 
    [SerializeField] private int slotindex;

    //상점에 처음 나오는 Item 세팅
    private void Start()
    {

        //자신의 번호
        slotindex = transform.GetSiblingIndex();
        //데이터베이스에서 가져옴
        slotitem =   SlotManager.Instance.itemDataBase.items[slotindex];

        //List에 슬롯을 저장
        SlotManager.Instance.slots.Add(slotitem);

        //자신의 버튼 컴포넌트를 가져옴
        clickBtn = GetComponent<Button>();
      
        //자신의 온클릭 이벤트 설정 - 
        clickBtn.onClick.AddListener(SetItemInfo);

        clickBtn.transform.GetChild(0).GetComponent<Image>().sprite = slotitem.animal;
        clickBtn.transform.GetChild(1).GetComponent<Text>().text = slotitem.price + "$";
        ////취소버튼 온클릭이벤트 설정
        SlotManager.Instance.shop.exitBtn.onClick.AddListener(ExitBtn);
    }

    // 자신의 아이템을 선택하게 되면 
    private void SetItemInfo()
    {
        //선택된 Item 으로 설정
        SlotManager.Instance.shop.selctItem = slotitem;
        SlotManager.Instance.shop.BuyBtn.onClick.RemoveAllListeners();
        ////구입버튼 온클릭이벤트 설정
        SlotManager.Instance.shop.BuyBtn.onClick.AddListener(BuyBtn);

    }
    public void BuyBtn()
    {
        //구입을 했을때 만약 자기 자신이 인벤토리에 추가되있다면 return
        if (SlotManager.Instance.invenSlots.Contains(slotitem))
        {
            return;
        }

        //만약 가지고 있는 소지자금이 구입하려는 아이템보다 크다면 (넉넉)
        if (MoneyManager.money >= slotitem.price)
        {
            //구입하기 
            MoneyManager.money -= slotitem.price;
            
            //인벤토리에 슬롯 생성
            InvenSlot invenSlot = Instantiate(SlotManager.Instance.equip.invenSlotPrefabs, 
            SlotManager.Instance.equip.invenSlotParent.transform) as InvenSlot;
    
            //인벤토리에 구입한 아이템 저장
            invenSlot.myItem = slotitem;
            //인벤토리에 구입한 아이템의이미지 저장
            invenSlot.myImage.sprite = slotitem.animal;
            //인벤토리 슬롯 리스트에 저장
            SlotManager.Instance.invenSlots.Add(slotitem);
        
        }


    }

    public void EquipBtn()
    {
        //장착버튼 클릭 시  - 싱글톤으로 만든 SlotManager. saveItem 에 저장
        SlotManager.Instance.saveItem = SlotManager.Instance.shop.selctItem;
        SlotManager.Instance.shop.gameObject.SetActive(false);


    }
    public void ExitBtn()
    {
        //취소버튼 클릭시 전부 NULL
        SlotManager.Instance.saveItem = null;
        SlotManager.Instance.shop.selctItem = null;
        SlotManager.Instance.shop.gameObject.SetActive(false);
    }


}
