using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    //상점에 표시될 slot 프리팹
    public Slot SlotPrefab;
    //생성될 프리팹의 부모 오브젝트
    public GameObject parent;

    [Header("상점 아이템 저장용")]
    public Item selctItem;
    [Header("구매버튼")]
    public Button BuyBtn;
    [Header("닫기버튼")]
    public Button exitBtn;

    //생성될 slot을 담을 리스트
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


        //데이타베이스에 저장되있는 아이템의 갯수
        int index = SlotManager.Instance.itemDataBase.items.Count;

        //셔플
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
            //리스트에 담는다.
            slotsObject.Add(slot.gameObject);
        }

    }
}
