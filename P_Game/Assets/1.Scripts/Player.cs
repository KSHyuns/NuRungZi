using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject bullet;   // 공격 시 사용되는 탄환입니다.
    public void Attack()
    {        
       Instantiate(bullet,new Vector3(gameObject.transform.position.x+0.4f, gameObject.transform.position.y+1f, gameObject.transform.position.z), Quaternion.identity);          // bullet(Prefab)을 생성합니다.
    }
}
