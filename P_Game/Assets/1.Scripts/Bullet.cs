using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    float rotateSpeed = 500f;       // Bullet의 회전속도를 지정합니다.

    public int damage = 4;                 // bullet의 데미지입니다.
    [SerializeField] Transform target;               // target(Enemy)의 transform정보를 가져오기 위함입니다.
    public float Speed = 10f;       // Bullet의 속도입니다.
    public float HeightArc = 1f;    // Bullet의 투척각도입니다. (수치변경은 Bullet 프리팹에 인스펙터 창을 이용해주세요.)

    private Vector3 StartPosition;  // 오브젝트 생성 위치를 저장해줍니다.
    private bool IsStart;           // 적의 유무를 체크합니다. 추후 변경 또는 제거될 수 있는 코드입니다.

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Dummy").transform;               // target의 Vector 값을 Enemy(Tag)의 좌표로 설정합니다.
        StartPosition = transform.position;                                         // Bullet의 처음 위치입니다.
       // enemyHp = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0,0,-Time.deltaTime*rotateSpeed,Space.Self);    // 오브젝트를 회전시킵니다.

        if (target != null)  // 타겟 오브젝트(Enemy)가 있다면
        {
            IsStart = true; // IsStart를 true로 변경합니다.
        }
        else
            return;

        if (IsStart)         // 적이 있다면
        {
            // 아래는 모두 포물선 공식입니다.
            // 업데이트 함수의 주석들을 제거하면 오브젝트가 회전하지 않고 Enemy방향을 보고 날아갑니다.(앵그리버드처럼)

            float x0 = StartPosition.x;
            float x1 = target.position.x;
            float distance = x1 - x0;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, Speed * Time.deltaTime);
            float baseY = Mathf.Lerp(StartPosition.y, target.position.y, (nextX - x0) / distance);
            float arc = HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);

            Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);
            //transform.rotation = LookAt2D(nextPosition - transform.position);

            transform.position = nextPosition;

            if (nextPosition == target.position)
                Destroy(gameObject);
        }


        /*Quaternion LookAt2D(Vector2 forward)
        {
            return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<Player>().enemy.maxHp -= damage;
            
            //enemyHp.maxHp -= damage;

           // Debug.Log(enemyHp.maxHp);

            Destroy(gameObject);
        }
    }
}

