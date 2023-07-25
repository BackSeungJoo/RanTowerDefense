using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;

    public float spawnWait = 0.5f;
    public float spawnedTime = 0;
    public int enemyCount = 0;

    public bool isGaming = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if : 게임이 시작 되면 적 생성
        if (isGaming)
        {
            // 스폰시간 마다 에너미 생성
            spawnedTime += Time.deltaTime;

            // 스폰 시간이 지났고, 특정 마리가 생성되지 않았다면
            if (spawnedTime > spawnWait && enemyCount <= 100)
            {
                Debug.Log("적생성");
                GameObject newEnemy = Instantiate(enemyPrefabs, this.gameObject.transform.position, gameObject.transform.rotation);
                enemyCount++;
                spawnedTime = 0;
            }
        }
    }
}
