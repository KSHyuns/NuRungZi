using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotation : MonoBehaviour
{
    //회전 각도
    [Tooltip("회전각도")]
    public float rotSpeed;

    private void Update()
    {
        rotSpeed %= 360;
        rotSpeed += Time.deltaTime *5f;
        transform.rotation = Quaternion.Euler(0,0, rotSpeed);
    }

}
