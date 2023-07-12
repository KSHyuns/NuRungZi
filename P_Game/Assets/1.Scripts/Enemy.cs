using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 20;
    //public Animator Death;


    public void OnEnable()
    {
        maxHp = 20;
    }

    private void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(5.15f, -1), 15f * Time.deltaTime);

        if (maxHp <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    IEnumerator Death()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}