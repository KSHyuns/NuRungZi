using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnter : MonoBehaviour
{

    private Vector2 endpos= new();
    [Range(0,359)]
    public float angle;
    [Range(0, 30)]
    public float distance;

    public float EndAngle;
    public float duration;

    [SerializeField] private Transform Earth;

    private void Update()
    {
        float t = ((angle %= 360) + 90f) * (Mathf.PI / 180f);
        endpos.x = Mathf.Cos(t) * distance;
        endpos.y = Mathf.Sin(t) * distance;

        transform.position = endpos + (Vector2)Earth.position;
        EnemyMoveRot(this.gameObject);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DOTween.To(() => angle, x => angle = x, EndAngle, duration);
        }

    }


    //0,0을 바라보는 각도
    private void EnemyMoveRot(GameObject enemy)
    {
        float r = Mathf.Atan2(endpos.y, endpos.x) * Mathf.Rad2Deg;

        enemy.transform.rotation = Quaternion.Euler(0, 0, r - 90f);

    }
}
