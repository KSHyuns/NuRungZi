using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;  // 적 프리팹
    public float spawnDelay = 1f;   // 스폰 딜레이
    
    bool isGameClear = true;        // 게임 클리어 여부를 체크합니다. (true = 클리어x, false = 클리어)
    int killCount = 0;              // 잡은 적의 마릿수를 체크합니다.
    int stageClear = 3;             // 잡아야하는 적의 마릿수를 나타냅니다.

    private void Start()
    {
        StartCoroutine(SpawnEnemy());   // Enemy spawn 코루틴
    }

    private IEnumerator SpawnEnemy()
    {
        while (isGameClear)                                 // 게임 클리어 상태가 아니라면
        {
            yield return new WaitForSeconds(spawnDelay);    // (적)스폰 딜레이만큼 대기

            // 적 생성
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // 적의 체력이 0이 되면 다음 적 스폰
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            FindObjectOfType<Player>().enemy = enemyHealth;

            while (enemyHealth.maxHp > 0)
            {
                yield return null;
            }

           
            Destroy(enemy); // 체력이 0이 된 적 Destroy

            killCount++;    // 잡은 적의 마릿수 1증가

            // 잡은 적의 마릿수가 잡아야하는 적의 마릿수와 같다면 isGameOver를 false로 만들어줍니다.
            if (killCount == stageClear)
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
