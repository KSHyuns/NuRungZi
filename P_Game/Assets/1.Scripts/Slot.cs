using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //슬롯은 버튼 컴포넌트를 가지고있슴.
    private Button clickBtn;
    //자기자신의 아이템
    public Item slotitem;
    //몇번째 자식인지 
    [SerializeField] private int slotindex;

   

    private Shop shop;
    private void Start()
    {
        //상점 가져옴
        shop = FindObjectOfType<Shop>();
        //자신의 자식번호
        slotindex = transform.GetSiblingIndex();
        //데이터베이스에서 가져옴
        slotitem =   SlotManager.Instance.itemDataBase.items[slotindex];
        //자신의 버튼 컴포넌트를 가져옴
        clickBtn = GetComponent<Button>();
        //자신의 온클릭 이벤트 설정 - 
        clickBtn.onClick.AddListener(SetItemInfo);

        clickBtn.transform.GetChild(0).GetComponent<Image>().sprite = slotitem.animal;
    }


    private void SetItemInfo()
    { 
        //선택된 Item 으로 설정
        shop.selctItem = slotitem;
        shop.selectItem_Sprite.sprite = shop.selctItem.animal;
        shop.selectItemInfo_Name.text = shop.selctItem.animalName;
        shop.selectItemInfo_Panel.gameObject.SetActive(true);

        
        shop.equipBtn.onClick.RemoveAllListeners();
        shop.exitBtn.onClick.RemoveAllListeners();

        //장착버튼 온클릭이벤트 설정
        shop.equipBtn.onClick.AddListener(EquipBtn);
        //취소버튼 온클릭이벤트 설정
        shop.exitBtn.onClick.AddListener(ExitBtn);

    }


    public void EquipBtn()
    {
        //장착버튼 클릭 시  - 싱글톤으로 만든 SlotManager. saveItem 에 저장
        SlotManager.Instance.saveItem = shop.selctItem;
        shop.selectItemInfo_Panel.gameObject.SetActive(false);

        //저장된 saveItem에 있는 동물 이름을 Text에 표시...
        shop.equipInfo_Name.text = SlotManager.Instance.saveItem.animalName;
        shop.equipInfo_Sprite.sprite = SlotManager.Instance.saveItem.animal;

    }
    public void ExitBtn()
    {
        //취소버튼 클릭시 전부 NULL
        SlotManager.Instance.saveItem = null;
        shop.selctItem = null;
        shop.selectItemInfo_Panel.gameObject.SetActive(false);
    }


}
