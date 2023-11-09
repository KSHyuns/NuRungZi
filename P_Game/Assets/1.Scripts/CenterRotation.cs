using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotation : MonoBehaviour
{
    //ȸ�� ����
    [Tooltip("ȸ������")]
    public float rotSpeed;

    private void Update()
    {
        rotSpeed %= 360;
        rotSpeed += Time.deltaTime *5f;
        transform.rotation = Quaternion.Euler(0,0, rotSpeed);
    }

}
