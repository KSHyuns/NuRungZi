using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //public Text atkCount;       // 어택버튼의 Max 카운트를 인게임에서 보여줄 수 있는 Text입니다. (임시코드입니다. 추후 변경 가능)

    public GameObject bullet;   // 공격 시 사용되는 탄환입니다.
    public Enemy enemy;

    /*public int maxAttackCount;         // 어택버튼을 누를 Max 카운트 수 입니다.
    public int numOfCount;             // 카운트가 넘어간 횟수입니다.

    InGameBtnManager Palse;*/

    /*void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;

        Palse = FindObjectOfType<InGameBtnManager>();
    }*/

    /*private void Update()
    {
        if (!Palse.isPause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (maxAttackCount == 1)
                {
                    numOfCount++;

                    maxAttackCount += numOfCount;

                    // 플레이어가 공격할 시 Bullet 프리팹을 생성합니다.
                    Attack();
                }

                maxAttackCount--;

                atkCount.text = maxAttackCount.ToString();
            }
        }
    }
    */
    public void Attack()
    {        
       var bt = Instantiate(bullet,new Vector3(gameObject.transform.position.x+0.4f, gameObject.transform.position.y+1f, gameObject.transform.position.z), Quaternion.identity);          // bullet(Prefab)을 생성합니다.
  
    }
}
