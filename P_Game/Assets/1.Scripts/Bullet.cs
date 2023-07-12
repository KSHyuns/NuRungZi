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

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Dummy").transform;               // target = bullet 도착지점
        StartPosition = transform.position;                                         // bullet 처음지점
    }

    void Update()
    {
        // bullet 회전
        gameObject.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
        // (Enemy)가 있다면 IsStart 실행
        if (target != null) { IsStart(); } //else return;
    }

    private void OnTriggerEnter2D(Collider2D collision) // bullet 발사체가 enemy 에 충돌뒤 스스로 파괴
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<Enemy>().maxHp -= damage; //HYJ0712 <Player>클래스에서 가져오던 enemy정보를 <Enemy>클래스에서 가져오도록 변경했습니다.
            Destroy(gameObject);
        }
    }
    void IsStart()
    {
        float x0 = StartPosition.x;
        float x1 = target.position.x;
        float distance = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, Speed * Time.deltaTime);
        float baseY = Mathf.Lerp(StartPosition.y, target.position.y, (nextX - x0) / distance);
        float arc = HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);

        Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);
        transform.position = nextPosition;
    }
}