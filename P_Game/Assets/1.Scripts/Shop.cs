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
    //public GameObject selectItemInfo_Panel;
    //public Image selectItem_Sprite;
    //public Text selectItemInfo_Name;
    //public Button equipBtn;
    public Button exitBtn;


   

    [Header("구매버튼")]
    public Button BuyBtn;

    public List<GameObject> slotsObject = new List<GameObject>();
    private void Start()
    {
        if (SlotManager.Instance.slots.Count >= 0)
        {
            foreach (var item in slotsObject)
            {
                Destroy(item);
            }
            slotsObject.Clear();   
        }


        //데이타베이스에 저장되있는 펫? 아이템? 의 갯수
        int index = SlotManager.Instance.itemDataBase.items.Count;

        for (int i = 0; i < 50; i++)
        {
            int nest = Random.Range(0, index);
            int dest = Random.Range(0, index);

            var temp = SlotManager.Instance.itemDataBase.items[nest];
            SlotManager.Instance.itemDataBase.items[nest] = SlotManager.Instance.itemDataBase.items[dest];
            SlotManager.Instance.itemDataBase.items[dest] = temp;
        }

        for (int i = 0; i < 3; i++)
        {
            //갯수만큼 생성 후 
            Slot slot =  Instantiate(SlotPrefab, parent.transform) ;

            slotsObject.Add(slot.gameObject);



        }

    }
}
