using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;  // 적 프리팹
    public float spawnDelay = 1f;   // 스폰 딜레이
    
    bool isGameClear = true;
    int killCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)
        {
            yield return new WaitForSeconds(spawnDelay);

            // 적 생성
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // 적의 체력이 0이 되면 다음 적 스폰
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            FindObjectOfType<Player>().enemy = enemyHealth;

            while (enemyHealth.maxHp > 0)
            {
                yield return null;
            }

            // 체력이 0이 된 적 삭제
            Destroy(enemy);
            killCount++;

            if (killCount > 3)
            {
                isGameClear= false;
            }
        }
    }

    /* public GameObject[] enemy = new GameObject[3];    // 테스트

     int index = 0;

     void Start()
     {
         Instantiate(enemy[0]);
     }

     void Update()
     {
         if (Time.deltaTime==1000000f)
         {
             index++;
             Instantiate(enemy[index]);
         }
     }*/
}
