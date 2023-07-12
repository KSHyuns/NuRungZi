using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // 적 프리팹
    public float spawnDelay = 1f;   // 스폰 딜레이

    bool isGameClear = false;
    public int killCount = 0, stageClear = 3;

    private void Start() { StartCoroutine(SpawnEnemy()); }
    private IEnumerator SpawnEnemy()
    {
        while (!isGameClear)
        {
            // delay 후 적 생성
            yield return new WaitForSeconds(spawnDelay);
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // 적의 체력이 0이하 되면 다음 적 스폰
            while (FindObjectOfType<Enemy>().maxHp > 0) { yield return null; }

            if (killCount == stageClear)
            { isGameClear = true; SceneManager.LoadScene(1); }
        }
    }
}
