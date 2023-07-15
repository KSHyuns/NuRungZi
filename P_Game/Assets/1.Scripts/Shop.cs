using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public Slot SlotPrefab;
    public GameObject parent;

    [Header("���� ������ �����")]
    public Item selctItem;

    [Header("����  ������ ���� �˾�â ������Ʈ")]
    //public GameObject selectItemInfo_Panel;
    //public Image selectItem_Sprite;
    //public Text selectItemInfo_Name;
    //public Button equipBtn;
    public Button exitBtn;


   

    [Header("���Ź�ư")]
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


        //����Ÿ���̽��� ������ִ� ��? ������? �� ����
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
            //������ŭ ���� �� 
            Slot slot =  Instantiate(SlotPrefab, parent.transform) ;

            slotsObject.Add(slot.gameObject);



        }

    }
}
