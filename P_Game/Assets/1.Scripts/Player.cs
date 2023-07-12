using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;   // 공격 시 사용되는 탄환입니다.

    public Text atkCount;       // 어택버튼의 Max 카운트를 인게임에서 보여줄 수 있는 Text입니다. (임시코드입니다. 추후 변경 가능)

    int maxAttackCount;         // 어택버튼을 누를 Max 카운트 수 입니다.
    int numOfCount;             // 카운트가 넘어간 횟수입니다.
    public Enemy enemy;
    void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;
       
    }

    public void AttackButton()  // 공격버튼에 관련된 코드입니다.
    {
        if (maxAttackCount == 1)
        {
            numOfCount++;

            maxAttackCount += numOfCount;
            Attack();
        }

        maxAttackCount--;

        atkCount.text = maxAttackCount.ToString();
    }

    public void Attack()
    {        
       var bt = Instantiate(bullet,new Vector3(gameObject.transform.position.x+0.4f, gameObject.transform.position.y+1f, gameObject.transform.position.z), Quaternion.identity);          // bullet(Prefab)을 생성합니다.
       
    }
}
